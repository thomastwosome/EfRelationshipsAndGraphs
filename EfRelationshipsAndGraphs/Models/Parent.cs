namespace EfRelationshipsAndGraphs.Models
{
    public class Parent
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Role { get; set; }

        public Child Child { get; set; }
    }
}