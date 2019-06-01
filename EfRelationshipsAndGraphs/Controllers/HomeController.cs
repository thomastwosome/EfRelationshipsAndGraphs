using EfRelationshipsAndGraphs.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using IndexViewModel = EfRelationshipsAndGraphs.ViewModels.IndexViewModel;

namespace EfRelationshipsAndGraphs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int parentId = 1)
        {
            using (var context = new ApplicationDbContext())
            {
                //context.Database.Log = Console.Write;
                context.Database.Log = message => Trace.Write(message);

                var parent = context.Parents.Include("Child").FirstOrDefault(x => x.Id == parentId);
                if (parent == null)
                    return HttpNotFound();


                var model = new IndexViewModel
                {
                    ParentId = parent.Id,
                    ParentFirstName = parent.FirstName,
                    ParentLastName = parent.LastName,
                    ParentRole = parent.Role,
                };

                if (parent.Child != null)
                {
                    model.ChildId = parent.Child.Id;
                    model.ChildFirstName = parent.Child.FirstName;
                    model.ChildLastName = parent.Child.LastName;
                    model.ChildAge = parent.Child.Age;
                }

                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IndexViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            using (var context = new ApplicationDbContext())
            {
                context.Database.Log = message => Trace.Write(message);

                var parent = context.Parents.Find(model.ParentId);

                if (parent == null)
                    return HttpNotFound();

                parent.FirstName = model.ParentFirstName;
                parent.LastName = model.ParentLastName;
                parent.Role = model.ParentRole;

                if (model.ChildId == 0) //new
                {
                    var child = new Child
                    {
                        Id = model.ParentId,
                        FirstName = model.ChildFirstName,
                        LastName = model.ChildLastName,
                        Age = model.ChildAge
                    };
                    context.Children.Add(child);
                }
                else
                {
                    var child = context.Children.Find(model.ChildId);
                    if (child != null)
                    {
                        //child.Id = model.ParentId;
                        child.FirstName = model.ChildFirstName;
                        child.LastName = model.ChildLastName;
                        child.Age = model.ChildAge;
                    }
                }

                context.SaveChanges();
                return RedirectToAction("Index", parent.Id);
            }
        }
    }
}