using EfRelationshipsAndGraphs.Models;
using EfRelationshipsAndGraphs.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace EfRelationshipsAndGraphs.Controllers
{
    public class MoeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new ApplicationDbContext())
            {
                var listModel = new MoeIndexViewModel();
                var entities = context.Moes.Include("Charter").ToList();
                foreach (var entity in entities)
                {
                    var model = new MoeViewModel
                    {
                        CharterName = entity.Charter.CharterName,
                        MoeId = entity.MoeId,
                        MoeName = entity.MoeName,
                    };
                    listModel.Moes.Add(model);
                }

                return View(listModel);
            }
        }

        public ActionResult Create(int charterId = 1)
        {
            using (var context = new ApplicationDbContext())
            {
                var charter = context.Charters.Find(charterId);
                var model = new MoeViewModel()
                {
                    CharterId = charter.CharterId,
                    CharterName = charter.CharterName
                };

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Create(MoeViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            using (var context = new ApplicationDbContext())
            {
                var entity = new Moe()
                {
                    CharterId = model.CharterId,
                    MoeName = model.MoeName,

                    Expenditure = new Expenditure()
                    {
                        Name = model.Expenditure.Name
                    }
                };

                if (!string.IsNullOrEmpty(model.DirectSupport.Name))
                {
                    entity.DirectSupport = new DirectSupport()
                    {
                        Name = model.DirectSupport.Name
                    };
                }

                if (!string.IsNullOrEmpty(model.Exemption.Name))
                {
                    entity.Exemption = new Exemption()
                    {
                        Name = model.Exemption.Name
                    };
                }

                context.Moes.Add(entity);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Read(int moeId)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context.Moes.Include("Charter")
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
        }

        public ActionResult Update(int moeId)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context.Moes.Include("Charter")
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
        }

        [HttpPost]
        public ActionResult Update(MoeViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            using (var context = new ApplicationDbContext())
            {
                var entity = context.Moes.Include("Charter")
                                        .Include("Expenditure")
                                        .Include("DirectSupport")
                                        .Include("Exemption")
                                        .Where(x => x.MoeId == model.MoeId).FirstOrDefault();
                entity.MoeName = model.MoeName;
                entity.Expenditure.Name = model.Expenditure.Name;

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

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int moeId)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context.Moes.Find(moeId);
                context.Moes.Remove(entity);
                context.SaveChanges();
            }
            return Json(Url.Action("Index"), JsonRequestBehavior.AllowGet);
        }

    }
}