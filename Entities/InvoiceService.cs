using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("InvoiceService")]
    public class InvoiceService
    {
        [Key]
        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }
        [Key]
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
    }
}