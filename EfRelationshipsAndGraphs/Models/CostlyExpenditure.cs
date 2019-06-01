namespace EfRelationshipsAndGraphs.Models
{
    public class CostlyExpenditure
    {
        public int CostlyExpenditureId { get; set; }

        public string CostlyExpenditureName { get; set; }

        
        /* Navigational Properties */

        public int MoeId { get; set; }
        public Exemption Exemption { get; set; }
    }
}