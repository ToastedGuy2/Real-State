using Entities;

namespace Web.Models
{
    public class HouseDto
    {
        public int HouseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Bathrooms { get; set; }
        public int Bedrooms { get; set; }
        public string Province { get; set; }
        public double Size { get; set; }
        public string[] Features { get; set; }
        public string ImageUrl { get; set; }
        public string RentMeUrl { get => $"/Rent/House/{HouseId}"; }
    }
}