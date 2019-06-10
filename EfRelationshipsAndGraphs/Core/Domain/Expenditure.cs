using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfRelationshipsAndGraphs.Core.Domain
{
    public class Expenditure
    {
        //[ForeignKey("Moe")]
        public int ExpenditureId { get; set; }

        public string ExpenditureName { get; set; }

        public virtual Moe Moe { get; set; }
    }
}