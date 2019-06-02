using System.Collections.Generic;

namespace EfRelationshipsAndGraphs.ViewModels
{
    public class MoeIndexViewModel
    {

        public MoeIndexViewModel()
        {
            Moes = new HashSet<MoeViewModel>();
        }

        public ICollection<MoeViewModel> Moes { get; set; }
    }
}