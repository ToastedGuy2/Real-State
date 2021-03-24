using System.Collections.Generic;
using Entities;
namespace Web.ViewModels.Rent
{
    public class RentListViewModel
    {
        public IEnumerable<Entities.House> Houses { get; set; }
        public IEnumerable<Province> Provinces { get; set; }
        public IEnumerable<Feature> Features { get; set; }
        public string ProvinceToCheck { get; internal set; }
    }
}