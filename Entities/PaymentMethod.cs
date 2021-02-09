using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("PaymentMethod")]
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
    }
}