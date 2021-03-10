using System.Collections.Generic;
using Entities;

namespace Web.ViewModels.House
{
    public class UpdateHouseViewModel : HouseViewModel
    {
        public int HouseId { get; set; }
        public string ImageName { get; set; }
    }
}