namespace EfRelationshipsAndGraphs.Core.Domain
{
    public class DirectSupport
    {
        public int DirectSupportId { get; set; }

        public string DirectSupportName { get; set; }

        public virtual Moe Moe { get; set; }
    }
}