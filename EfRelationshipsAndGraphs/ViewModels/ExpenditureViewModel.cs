using System.ComponentModel.DataAnnotations;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class ExpenditureViewModel
    {
        public int MoeId { get; set; }

        [Display(Name = "Expenditure")]
        public string Name { get; set; }
    }
}