using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("CreditCard")]
    public class CreditCard
    {
        [Key]
        public int CreditCardId { get; set; }
        [Required]
        public string NameOnCard { get; set; }
        [Required]
        [StringLength(16)]
        public string CreditCardNumber { get; set; }
        [Required]
        public string ExpirationDate { get; set; }
        [Required]
        [StringLength(3)]
        public int CVV { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [ForeignKey("AppUserId")]
        public AppUser Customer { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}