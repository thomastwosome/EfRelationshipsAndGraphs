namespace EfRelationshipsAndGraphs.Core.Domain
{
    public class Moe
    {
        public int MoeId { get; set; }

        public string Name { get; set; }

        public string ActualOrBudget { get; set; }

        public int RelatedMoeId { get; set; }


        /* Navigational Properties */
        public int CharterId { get; set; }
        public virtual Charter Charter { get; set; }

        public virtual Expenditure Expenditure { get; set; }
        public virtual DirectSupport DirectSupport { get; set; }
        public virtual Exemption Exemption { get; set; }

    }
}