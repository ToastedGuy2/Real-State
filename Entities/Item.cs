using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Item")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [ForeignKey("CategoryId")]
        public string Description { get; set; }
        public Category Category { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public string ImageName { get; set; }
        [Required]
        public bool IsItActive { get; set; }
        public IEnumerable<OrderItem> Orders { get; set; }
        public IEnumerable<BillItem> Bills { get; set; }
    }
}

