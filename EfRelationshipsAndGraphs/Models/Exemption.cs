using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfRelationshipsAndGraphs.Models
{
    public class Exemption
    {
        public Exemption()
        {
            Staffs = new HashSet<Staff>();
            Students = new HashSet<Student>();
            CostlyExpenditures = new HashSet<CostlyExpenditure>();
        }

        [Key, ForeignKey("Moe")]
        public int MoeId { get; set; }

        public string Name { get; set; }

        /* Navigational Properties */
        public Moe Moe { get; set; }

        public ICollection<Staff> Staffs { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<CostlyExpenditure> CostlyExpenditures { get; set; }
    }
}