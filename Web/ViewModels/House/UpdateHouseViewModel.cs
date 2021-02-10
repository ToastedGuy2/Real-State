using System.Collections.Generic;
using Entities;

namespace Web.ViewModels.House
{
    public class UpdateHouseViewModel : HouseViewModel
    {
        public int HouseId { get; set; }
        public IEnumerable<HouseFeature> SelectedFeatures { get; set; } = new List<HouseFeature>();
    }
}