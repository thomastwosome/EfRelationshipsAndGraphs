using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfRelationshipsAndGraphs.Models
{
    public class Child
    {
        [ForeignKey("Parent")]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Parent Parent { get; set; }

        public ICollection<Pet> Pets { get; set; }

    }
}