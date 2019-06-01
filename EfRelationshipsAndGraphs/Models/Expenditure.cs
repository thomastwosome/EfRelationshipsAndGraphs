using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfRelationshipsAndGraphs.Models
{
    public class Expenditure
    {
        [Key]
        public int MoeId { get; set; }

        public string Name { get; set; }

        public Moe Moe { get; set; }
    }
}