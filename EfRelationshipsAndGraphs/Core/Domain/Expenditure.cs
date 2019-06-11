namespace EfRelationshipsAndGraphs.Core.Domain
{
    public class Expenditure
    {
        public int ExpenditureId { get; set; }

        public string Name { get; set; }

        public virtual Moe Moe { get; set; }
    }
}