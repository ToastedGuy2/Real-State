using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Brand")]
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}