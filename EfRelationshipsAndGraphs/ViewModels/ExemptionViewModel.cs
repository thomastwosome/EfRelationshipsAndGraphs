using System.ComponentModel.DataAnnotations;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class ExemptionViewModel
    {
        public int MoeId { get; set; }

        [Display(Name = "Exemption")]
        public string Name { get; set; }
    }
}