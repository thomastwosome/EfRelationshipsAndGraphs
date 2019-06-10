namespace EfRelationshipsAndGraphs.Core.Domain
{
    public class Moe
    {
        public int MoeId { get; set; }

        public string MoeName { get; set; }

        public string ActualOrBudget { get; set; }

        public int RelatedMoeId { get; set; }


        /* Navigational Properties */
        public int CharterId { get; set; }
        public Charter Charter { get; set; }

        public virtual Expenditure Expenditure { get; set; }
        public virtual DirectSupport DirectSupport { get; set; }

        //public Exemption Exemption { get; set; }
    }
}