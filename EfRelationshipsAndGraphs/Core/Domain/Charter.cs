using System.Collections.Generic;

namespace EfRelationshipsAndGraphs.Core.Domain
{
    public class Charter
    {
        public Charter()
        {
            Moes = new HashSet<Moe>();
        }

        public int CharterId { get; set; }

        public string CharterName { get; set; }

        public ICollection<Moe> Moes { get; set; }
    }
}