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
        [Required]
        [ForeignKey("Id")]
        public string CustomerId { get; set; }
        [ForeignKey("Id")]
        public AppUser Customer { get; set; }
        [Required]
        public int HouseId { get; set; }
        [ForeignKey("HouseId")]
        public House House { get; set; }
        [Required]
        public DateTimeOffset StartDate { get; set; }
        [Required]
        public int Months { get; set; }
        [Required]
        public DateTimeOffset EndDate { get; set; }
        [Required]
        public double SubTotal { get; set; }
        [Required]
        public ICollection<BillService> Services { get; set; } = new List<BillService>();
        [Required]
        public double Iva { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public int PaymentMethodId { get; set; }
        [ForeignKey("PaymentMethodId")]
        public PaymentMethod PaymentMethod { get; set; }
    }
}