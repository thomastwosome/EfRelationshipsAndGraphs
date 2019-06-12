using EfRelationshipsAndGraphs.Core.Domain;
using EfRelationshipsAndGraphs.Persistance;
using EfRelationshipsAndGraphs.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;

namespace EfRelationshipsAndGraphs.Controllers
{
    public class MoeController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var entities = _db.Moes.Include("Charter").ToList();
            var models = entities.ToCollection();

            return View(models);
        }

        private MoeViewModel PrepareModel(int moeId)
        {
            var moe = _db.Moes
                .Include("Charter")
                .Include("Expenditure")
                .Include("DirectSupport")
                .Include("Exemption")
                .FirstOrDefault(x => x.MoeId == moeId);

            var model = moe.ToModel();
            model.CostlyExpenditures = CreateExpendituresList(model.MoeId);
            return model;
        }

        public ActionResult Create(int charterId = 1)
        {
            var charter = _db.Charters.Find(charterId);
            var model = charter.ToModel();
            model.CostlyExpenditures = CreateExpendituresList(model.MoeId);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoeViewModel model)
        {
            ActionResult actionResult;
            if (Save(ref model, out actionResult))
                return actionResult;
            return View(model);
        }

        public ActionResult Read(int moeId)
        {
            var model = PrepareModel(moeId);
            return View(model);
        }

        public ActionResult Update(int moeId)
        {
            var model = PrepareModel(moeId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(MoeViewModel model)
        {
            ActionResult actionResult;
            if (Save(ref model, out actionResult))
                return actionResult;
            return View(model);
        }

        private bool Save(ref MoeViewModel model, out ActionResult actionResult)
        {
            _db.Database.Log = message => Trace.Write(message);
            if (!ModelState.IsValid)
            {
                actionResult = View(model);
                return false;
            }

            var moeId = model.MoeId;
            var moe = _db.Moes.Include("Expenditure")
                .Include("DirectSupport")
                .Include("Exemption")
                                .FirstOrDefault(x => x.MoeId == moeId);

            if (moe == null) //Create
            {
                moe = model.ToEntity();
                _db.Moes.Add(moe);
            }
            else //Update
            {
                moe.Name = model.MoeName;
                //moe = model.ToEntity(); //Why doesn't this work?

                //Add/Edits
                if (model.ExpenditureName != null)
                    moe.Expenditure = Mapper.Map<MoeViewModel, Expenditure>(model);

                if (model.DirectSupportName != null)
                    moe.DirectSupport = Mapper.Map<MoeViewModel, DirectSupport>(model);

                if (model.ExemptionName != null)
                    moe.Exemption = Mapper.Map<MoeViewModel, Exemption>(model);

                //Deletions
                if (model.ExpenditureName == null)
                {
                    var expenditure = moe.Expenditure;
                    if (expenditure != null) _db.Expenditures.Remove(expenditure);
                }
                if (model.DirectSupportName == null)
                {
                    var directSupport = moe.DirectSupport;
                    if (directSupport != null) _db.DirectSupports.Remove(directSupport);
                }
                if (model.ExemptionName == null)
                {
                    var exemption = moe.Exemption;
                    if (exemption != null) _db.Exemptions.Remove(exemption);
                }
            }

            var entries = _db.ChangeTracker.Entries().ToList();
            foreach (var entry in entries)
            {
                Console.WriteLine(entry.State);
            }

            _db.SaveChanges();
            actionResult = RedirectToAction("Index");
            return true;
        }

        public ActionResult Delete(int moeId)
        {
            var moe = _db.Moes.Find(moeId);
            if (moe == null)
                return HttpNotFound();

            _db.Moes.Remove(moe);
            _db.SaveChanges();

            return Json(Url.Action("Index"), JsonRequestBehavior.AllowGet);
        }

        public List<CostlyExpenditureViewModel> CreateExpendituresList(int moeId)
        {
            var models = new List<CostlyExpenditureViewModel>();
            //New row
            var newModel = new CostlyExpenditureViewModel
            {
                MoeId = moeId,
                Description = string.Empty,
                Total = null
            };
            models.Add(newModel);

            var entity = _db.Moes.Include("Exemption.CostlyExpenditures")
                                    .FirstOrDefault(x => x.MoeId == moeId);

            if (entity?.Exemption != null)
            {
                var existExps = entity.Exemption.CostlyExpenditures;
                var existExpsModels = existExps.ToCollection();
                models.AddRange(existExpsModels);
            }

            return models;
        }

        [HttpPost]
        public ActionResult UpdateExpenditures(List<CostlyExpenditureViewModel> list, int moeId, int charterId)
        {
            if (charterId == 0)
                return Json(new { success = false, message = "You must pick a Charter School first." });

            //if (list == null || list.Count == 0)
            //    return Json(new { success = false, message = "No changes submitted." });

            //if (moeId == 0)
            //    moeId = GetMoeId(charterId);

            //var exemptionId = GetExemptionId(moeId, charterId);

            foreach (var item in list)
            {
                if (string.IsNullOrEmpty(item.Description))
                    return Json(new { success = false, message = "Please provide a name." });

                if (item.CostlyExpenditureId == 0)
                {
                    var entity = Mapper.Map<CostlyExpenditure>(item);
                    entity.MoeId = moeId; //Why?
                    _db.CostlyExpenditures.Add(entity);
                }
                else
                {
                    var entity = _db.CostlyExpenditures.Find(item.CostlyExpenditureId);
                    if (entity != null)
                    {
                        entity.Description = item.Description;
                        entity.Total = Convert.ToDecimal(item.Total);
                    }
                }
            }

            _db.SaveChanges();

            var newList = CreateExpendituresList(moeId);

            return Json(new
            {
                success = true,
                partial = CommonHelpers.RenderPartialToString(this, "_CostlyExpenditure", null, newList)
            });
        }

        public ActionResult DeleteExpenditure(int moeId, int id)
        {
            var moe = _db.Moes
                        .Include("CostlyExpenditures")
                        .FirstOrDefault(x => x.MoeId == moeId);

            var expToDelete = moe.Exemption.CostlyExpenditures.FirstOrDefault(x => x.CostlyExpenditureId == id);
            moe.Exemption.CostlyExpenditures.Remove(expToDelete);
            _db.SaveChanges();

            var list = CreateExpendituresList(moe.MoeId);

            return Json(new
            {
                success = true,
                partial = CommonHelpers.RenderPartialToString(this, "_CostlyExpenditure", null, list)
            });
        }
    }
}