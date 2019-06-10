using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class ExemptionViewModel
    {
        //public ExemptionViewModel()
        //{
        //    CostlyExpenditures = new List<CostlyExpenditureViewModel>();
        //}

        public int MoeId { get; set; }

        [Display(Name = "Exemption")]
        public string Name { get; set; }

        //public List<CostlyExpenditureViewModel> CostlyExpenditures { get; set; }
        public string CostlyExpendituresTotal { get; set; }
    }
}