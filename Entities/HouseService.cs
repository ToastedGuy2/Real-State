using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("HouseService")]
    public class HouseService
    {
        [Key]
        public int HouseId { get; set; }
        [ForeignKey("HouseId")]
        public House House { get; set; }
        [Key]
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public Service Service { get; set; }
    }
}