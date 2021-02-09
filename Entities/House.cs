using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("House")]
    public class House
    {
        [Key]
        public int HouseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Bathrooms { get; set; }
        [Required]
        public int Bedrooms { get; set; }
        [Required]
        public double Size { get; set; }
        [Required]
        public bool IsItAvailable { get; set; }
        [Required]
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public Province Province { get; set; }
        public string ImageName { get; set; }
        public ICollection<HouseService> Services { get; set; } = new List<HouseService>();
        public ICollection<HouseFeature> Features { get; set; } = new List<HouseFeature>();

    }
}