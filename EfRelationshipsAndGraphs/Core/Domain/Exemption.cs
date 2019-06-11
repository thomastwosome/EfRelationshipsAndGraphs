using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfRelationshipsAndGraphs.Core.Domain
{
    public class Exemption
    {
        //public Exemption()
        //{
        //    Staffs = new HashSet<Staff>();
        //    Students = new HashSet<Student>();
        //    CostlyExpenditures = new HashSet<CostlyExpenditure>();
        //}

        public int ExemptionId { get; set; }

        public string ExemptionName { get; set; }

        //public decimal CostlyExpendituresTotal { get; set; }

        /* Navigational Properties */
        public virtual Moe Moe { get; set; }

        //public ICollection<Staff> Staffs { get; set; }
        //public ICollection<Student> Students { get; set; }
        //public ICollection<CostlyExpenditure> CostlyExpenditures { get; set; }
    }
}