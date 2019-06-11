﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfRelationshipsAndGraphs.Core.Domain
{
    public class Expenditure
    {
        [Key, ForeignKey("Moe")]
        public int MoeId { get; set; }

        public string Name { get; set; }

        public virtual Moe Moe { get; set; }
    }
}