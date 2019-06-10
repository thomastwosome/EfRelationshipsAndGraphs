using System.ComponentModel.DataAnnotations;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class DirectSupportViewModel
    {
        public int DirectSupportId { get; set; }

        [Display(Name = "Direct Support")]
        public string DirectSupportName { get; set; }
    }
}