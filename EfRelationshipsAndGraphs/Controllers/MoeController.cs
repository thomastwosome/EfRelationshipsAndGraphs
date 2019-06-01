using EfRelationshipsAndGraphs.Models;
using EfRelationshipsAndGraphs.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace EfRelationshipsAndGraphs.Controllers
{
    public class MoeController : Controller
    {
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
                var moe = new Moe()
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
                    moe.DirectSupport = new DirectSupport()
                    {
                        Name = model.DirectSupport.Name
                    };
                }

                if (!string.IsNullOrEmpty(model.Exemption.Name))
                {
                    moe.Exemption = new Exemption()
                    {
                        Name = model.Exemption.Name
                    };
                }

                context.Moes.Add(moe);
                context.SaveChanges();
            }

            return RedirectToAction("Create", model.CharterId);
        }

        public ActionResult Update(int moeId = 3)
        {
            using (var context = new ApplicationDbContext())
            {
                var moe = context.Moes.Include("Charter")
                                        .Include("Expenditure")
                                        .Include("DirectSupport")
                                        .Include("Exemption")
                                        .Where(x => x.MoeId == moeId).FirstOrDefault();
                var model = new MoeViewModel()
                {
                    MoeId = moe.MoeId,
                    MoeName = moe.MoeName,
                    CharterId = moe.CharterId,
                    CharterName = moe.Charter.CharterName,
                    
                };
                model.Expenditure = new ExpenditureViewModel()
                {
                    Name = moe.Expenditure.Name
                };
                model.DirectSupport = new DirectSupportViewModel()
                {
                    Name = (moe.DirectSupport != null) ? moe.DirectSupport.Name : null
                };
                model.Exemption = new ExemptionViewModel()
                {
                    Name = (moe.Exemption != null) ? moe.Exemption.Name : null
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
                entity.DirectSupport.Name = model.DirectSupport.Name;
                entity.Exemption.Name = model.Exemption.Name;

                context.SaveChanges();
            }

            return RedirectToAction("Update", model.MoeId);
        }

    }
}