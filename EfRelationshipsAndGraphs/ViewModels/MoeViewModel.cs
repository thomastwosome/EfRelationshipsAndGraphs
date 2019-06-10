using System.ComponentModel.DataAnnotations;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class MoeViewModel
    {
        public int MoeId { get; set; }

        [Required]
        [Display(Name = "MOE Name")]
        public string MoeName { get; set; }

        public string ActualOrBudget { get; set; }

        public int RelatedMoeId { get; set; }

        public int CharterId { get; set; }

        [Display(Name = "Charter")]
        public string CharterName { get; set; }

        public int ExpenditureId { get; set; }

        [Display(Name = "Expenditure")]
        public string ExpenditureName { get; set; }
    }
}