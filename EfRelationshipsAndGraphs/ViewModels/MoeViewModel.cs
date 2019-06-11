using System.ComponentModel.DataAnnotations;
using EfRelationshipsAndGraphs.Core.Domain;

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
        public virtual Expenditure Expenditure { get; set; }

        public int DirectSupportId { get; set; }

        [Display(Name = "Direct Support")]
        public string DirectSupportName { get; set; }

        public virtual DirectSupport DirectSupport { get; set; }

        public int ExemptionId { get; set; }

        [Display(Name = "One-Time Exemption")]
        public string ExemptionName { get; set; }

        public virtual Exemption Exemption { get; set; }
    }
}