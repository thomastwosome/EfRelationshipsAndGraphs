using System.ComponentModel.DataAnnotations;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class ExpenditureViewModel
    {
        public int MoeId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}