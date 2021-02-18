using Entities;

namespace Web.Dto
{
    public class HouseDto
    {
        public int HouseId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Bathrooms { get; set; }
        public int Bedrooms { get; set; }
        public Province Province { get; set; }
        public int[] FeaturesId { get; set; }
        public string ImageUrl { get; set; }
        public string RentMeUrl { get => $"/Rent/House/{HouseId}"; }
    }
}