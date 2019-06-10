using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfRelationshipsAndGraphs.Core.Domain
{
    public class DirectSupport
    {
        [Key] //, ForeignKey("Moe")
        public int MoeId { get; set; }

        public string Name { get; set; }

        public Moe Moe { get; set; }
    }
}