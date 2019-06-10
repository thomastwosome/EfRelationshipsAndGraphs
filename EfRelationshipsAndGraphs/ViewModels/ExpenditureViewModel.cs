using System.ComponentModel.DataAnnotations;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class ExpenditureViewModel
    {
        public int ExpenditureId { get; set; }

        //[Required]
        [Display(Name = "Expenditure")]
        public string ExpenditureName { get; set; }
    }
}