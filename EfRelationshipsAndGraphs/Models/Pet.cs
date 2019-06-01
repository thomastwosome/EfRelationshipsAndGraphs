namespace EfRelationshipsAndGraphs.Models
{
    public class Pet
    {
        public int Id { get; set; }

        public string Species { get; set; }

        public string Gender { get; set; }

        public string Name { get; set; }

        public int ChildId { get; set; }
        public Child Child { get; set; }

    }
}