using System.ComponentModel.DataAnnotations;

namespace EfRelationshipsAndGraphs.Core.Domain
{
    public class CostlyExpenditure
    {
        public int CostlyExpenditureId { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public decimal Total { get; set; }


        /* Navigational Properties */

        public int MoeId { get; set; }
        public Exemption Exemption { get; set; }
    }
}