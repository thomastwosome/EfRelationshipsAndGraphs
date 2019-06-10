using AutoMapper;
using EfRelationshipsAndGraphs.Core.Domain;
using EfRelationshipsAndGraphs.ViewModels;
using System;
using System.Web.Mvc;

namespace EfRelationshipsAndGraphs.Controllers
{
    public class ProjectionController : Controller
    {
        // GET: Projection
        public ActionResult Index()
        {
            var calendarEvent = new CalendarEvent
            {
                Date = new DateTime(2008, 12, 15, 20, 30, 0),
                Title = "Company Holiday Party"
            };


            // Perform mapping
            CalendarEventForm form = Mapper.Map<CalendarEvent, CalendarEventForm>(calendarEvent);

            //form.EventDate.ShouldEqual(new DateTime(2008, 12, 15));
            //form.EventHour.ShouldEqual(20);
            //form.EventMinute.ShouldEqual(30);
            //form.Title.ShouldEqual("Company Holiday Party");

            return View();
        }
    }
}