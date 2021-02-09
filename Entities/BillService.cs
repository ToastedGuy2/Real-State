using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("BillService")]
    public class BillService
    {
        [Key]
        public int BillId { get; set; }
        [ForeignKey("BillId")]
        public Bill Bill { get; set; }
        [Key]
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
    }
}