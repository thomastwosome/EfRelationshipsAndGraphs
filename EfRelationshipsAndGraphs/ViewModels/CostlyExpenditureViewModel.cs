using System.ComponentModel.DataAnnotations;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class CostlyExpenditureViewModel
    {
        public int CostlyExpenditureId { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public string Total { get; set; }


        /* Navigational Properties */

        public int MoeId { get; set; }
        public ExemptionViewModel Exemption { get; set; }
    }
}