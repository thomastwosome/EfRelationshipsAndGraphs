using System.ComponentModel.DataAnnotations;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class MoeViewModel
    {
        public int MoeId { get; set; }
        [Required]
        public string MoeName { get; set; }


        public int CharterId { get; set; }
        public string CharterName { get; set; }

        public ExpenditureViewModel Expenditure { get; set; }
        public DirectSupportViewModel DirectSupport { get; set; }
        public ExemptionViewModel Exemption { get; set; }

    }
}