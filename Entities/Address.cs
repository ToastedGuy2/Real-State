using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string Canton { get; set; }
        [Required]
        public string District { get; set; }
        [Required]
        public string ExactAddress { get; set; }
        [ForeignKey("Id")]
        public AppUser Customer { get; set; }
        [Required]
        public string CustomerId { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public bool IsItActive { get; set; }
    }
}