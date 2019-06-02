using EfRelationshipsAndGraphs.Models;
using EfRelationshipsAndGraphs.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace EfRelationshipsAndGraphs.Controllers
{
    public class MoeController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var models = _db.Moes.Include("Charter").Select(x => new MoeViewModel()
            {
                CharterName = x.Charter.CharterName,
                MoeId = x.MoeId,
                MoeName = x.MoeName
            }).ToList();

            return View(models);
        }

        public ActionResult Create(int charterId = 1)
        {
            var charter = _db.Charters.Find(charterId);
            var model = new MoeViewModel()
            {
                CharterId = charter.CharterId,
                CharterName = charter.CharterName
            };

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
            var entity = _db.Moes.Include("Charter")
                                    .Include("Expenditure")
                                    .Include("DirectSupport")
                                    .Include("Exemption")
                                    .Where(x => x.MoeId == moeId).FirstOrDefault();
            var model = new MoeViewModel()
            {
                MoeId = entity.MoeId,
                MoeName = entity.MoeName,
                CharterId = entity.CharterId,
                CharterName = entity.Charter.CharterName,

            };
            model.Expenditure = new ExpenditureViewModel()
            {
                Name = entity.Expenditure.Name
            };
            model.DirectSupport = new DirectSupportViewModel()
            {
                Name = (entity.DirectSupport != null) ? entity.DirectSupport.Name : null
            };
            model.Exemption = new ExemptionViewModel()
            {
                Name = (entity.Exemption != null) ? entity.Exemption.Name : null
            };

            return View(model);
        }

        public ActionResult Update(int moeId)
        {
            var entity = _db.Moes.Include("Charter")
                                    .Include("Expenditure")
                                    .Include("DirectSupport")
                                    .Include("Exemption")
                                    .Where(x => x.MoeId == moeId).FirstOrDefault();
            var model = new MoeViewModel()
            {
                MoeId = entity.MoeId,
                MoeName = entity.MoeName,
                CharterId = entity.CharterId,
                CharterName = entity.Charter.CharterName,
                    
            };
            model.Expenditure = new ExpenditureViewModel()
            {
                Name = entity.Expenditure.Name
            };
            model.DirectSupport = new DirectSupportViewModel()
            {
                Name = (entity.DirectSupport != null) ? entity.DirectSupport.Name : null
            };
            model.Exemption = new ExemptionViewModel()
            {
                Name = (entity.Exemption != null) ? entity.Exemption.Name : null
            };

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
            if (!ModelState.IsValid)
            {
                actionResult = View(model);
                return false;
            }

            Moe entity;
            if (model.MoeId == 0) //Create
            {
                entity = new Moe()
                {
                    CharterId = model.CharterId,
                    MoeName = model.MoeName,

                    Expenditure = new Expenditure()
                    {
                        Name = model.Expenditure.Name
                    }
                };
                _db.Moes.Add(entity);
            }
            else //Update
            {
                var moeId = model.MoeId;
                entity = _db.Moes.Include("Charter")
                                                    .Include("Expenditure")
                                                    .Include("DirectSupport")
                                                    .Include("Exemption")
                                                    .Where(x => x.MoeId == moeId).FirstOrDefault();
                entity.MoeName = model.MoeName;
                entity.Expenditure.Name = model.Expenditure.Name;
            }

            //Direct Support
            if (entity.DirectSupport != null)
            {
                entity.DirectSupport.Name = model.DirectSupport.Name;
            }
            if (!string.IsNullOrEmpty(model.DirectSupport.Name))
            {
                entity.DirectSupport = new DirectSupport()
                {
                    Name = model.DirectSupport.Name
                };
            }

            //Exemption
            if (entity.Exemption != null)
            {
                entity.Exemption.Name = model.Exemption.Name;
            }

            if (!string.IsNullOrEmpty(model.Exemption.Name))
            {
                entity.Exemption = new Exemption()
                {
                    Name = model.Exemption.Name
                };
            }

            _db.SaveChanges();
            actionResult = RedirectToAction("Index");
            return true;
        }

        public ActionResult Delete(int moeId)
        {
            var entity = _db.Moes.Find(moeId);
            _db.Moes.Remove(entity);
            _db.SaveChanges();

            return Json(Url.Action("Index"), JsonRequestBehavior.AllowGet);
        }
    }
}