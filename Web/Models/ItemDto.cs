using AutoMapper;

namespace Web.Models
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
    }
}