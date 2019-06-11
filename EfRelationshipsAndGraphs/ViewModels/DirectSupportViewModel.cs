using System.ComponentModel.DataAnnotations;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class DirectSupportViewModel
    {
        public int MoeId { get; set; }

        [Display(Name = "Direct Support")]
        public string Name { get; set; }
    }
}