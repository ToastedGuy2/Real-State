using System.Collections.Generic;
namespace Web.ViewModels.House
{
    using Entities;
    public class DetailsHouseViewModel
    {
        public Entities.House House { get; set; }
        public ICollection<Feature> FeaturesToDisplay { get; set; }
    }
}