using System.ComponentModel.DataAnnotations;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class MoeViewModel
    {
        public int MoeId { get; set; }

        [Required]
        [Display(Name = "MOE Name")]
        public string MoeName { get; set; }


        public int CharterId { get; set; }

        [Display(Name = "Charter")]
        public string CharterName { get; set; }

        public ExpenditureViewModel Expenditure { get; set; }
        public DirectSupportViewModel DirectSupport { get; set; }
        public ExemptionViewModel Exemption { get; set; }

    }
}