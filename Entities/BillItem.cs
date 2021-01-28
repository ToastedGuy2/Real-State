using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("BillItem")]
    public class BillItem
    {
        [Key]
        public int BillId { get; set; }
        [ForeignKey("BillId")]
        public Bill Bill { get; set; }
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