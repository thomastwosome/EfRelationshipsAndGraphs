using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class CalendarEventForm
    {
        public DateTime EventDate { get; set; }
        public int EventHour { get; set; }
        public int EventMinute { get; set; }
        public string Title { get; set; }
    }
}