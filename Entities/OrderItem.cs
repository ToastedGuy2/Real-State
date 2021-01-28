using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("OrderItem")]
    public class OrderItem
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [Key]
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double SubTotal { get; set; }
        [Required]
        public double Iva { get; set; }
        [Required]
        public double Total { get; set; }
    }
}