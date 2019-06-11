namespace EfRelationshipsAndGraphs.Core.Domain
{
    public class DirectSupport
    {
        public int DirectSupportId { get; set; }

        public string Name { get; set; }

        public virtual Moe Moe { get; set; }
    }
}