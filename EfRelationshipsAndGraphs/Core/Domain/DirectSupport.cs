namespace EfRelationshipsAndGraphs.Core.Domain
{
    public class DirectSupport
    {
        //[Key] //, ForeignKey("Moe")
        public int DirectSupportId { get; set; }

        public string DirectSupportName { get; set; }

        public Moe Moe { get; set; }
    }
}