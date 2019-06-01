using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class IndexViewModel
    {
        public int ParentId { get; set; }
        public string ParentFirstName { get; set; }
        public string ParentLastName { get; set; }
        public string ParentRole { get; set; }

        public int ChildId { get; set; }
        public string ChildFirstName { get; set; }
        public string ChildLastName { get; set; }
        public int ChildAge { get; set; }
    }
}