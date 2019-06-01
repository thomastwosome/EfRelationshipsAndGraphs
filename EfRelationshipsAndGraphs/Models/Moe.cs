namespace EfRelationshipsAndGraphs.Models
{
    public class Moe
    {
        public int MoeId { get; set; }

        public string MoeName { get; set; }


        /* Navigational Properties */
        public int CharterId { get; set; }
        public Charter Charter { get; set; }

        public Expenditure Expenditure { get; set; }
        public DirectSupport DirectSupport { get; set; }
        public Exemption Exemption { get; set; }
    }
}