using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Bill")]
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        [ForeignKey("Id")]
        [Required]
        public string CustomerId { get; set; }
        [ForeignKey("Id")]
        public AppUser Customer { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }
        [Required]
        public int CreditCardId { get; set; }
        [ForeignKey("CreditCardId")]
        public CreditCard CreditCard { get; set; }
        [Required]
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address DeliveryAddress { get; set; }
        public IEnumerable<BillItem> Items { get; set; }
        public double SubTotal { get; set; }
        public double Iva { get; set; }
        public double Total { get; set; }
    }
}