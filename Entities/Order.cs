using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("Id")]
        [Required]
        public string ClientId { get; set; }
        [ForeignKey("Id")]
        public AppUser Client { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}