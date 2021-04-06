using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [Required]
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<InvoiceService> Invoices { get; set; } = new List<InvoiceService>();
        [JsonIgnore]
        public ICollection<HouseService> Houses { get; set; } = new List<HouseService>();
    }
}