using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Service")]
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public ICollection<BillService> Bills { get; set; } = new List<BillService>();
        public ICollection<HouseService> Houses { get; set; } = new List<HouseService>();
    }
}