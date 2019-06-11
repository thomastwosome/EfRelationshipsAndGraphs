using System.ComponentModel.DataAnnotations;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class ExemptionViewModel
    {
        //public ExemptionViewModel()
        //{
        //    CostlyExpenditures = new List<CostlyExpenditureViewModel>();
        //}

        public int ExemptionId { get; set; }

        [Display(Name = "One-Time Exemption")]
        public string ExemptionName { get; set; }

        //public List<CostlyExpenditureViewModel> CostlyExpenditures { get; set; }
        public string CostlyExpendituresTotal { get; set; }
    }
}