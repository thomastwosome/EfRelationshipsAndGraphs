using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class ExemptionViewModel
    {

        public int MoeId { get; set; }

        [Display(Name = "One-Time Exemption")]
        public string Name { get; set; }

        public string CostlyExpendituresTotal { get; set; }
    }
}