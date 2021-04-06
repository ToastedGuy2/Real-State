using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [ForeignKey("Id")]
        public AppUser Customer { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }
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
        public ICollection<InvoiceService> Services { get; set; } = new List<InvoiceService>();
        [Required]
        public double HomeSubTotal { get; set; }
        [Required]
        public double ServicesSubTotal { get; set; }
        [Required]
        public double SubTotal { get; set; }
        [Required]
        public double Tax { get; set; }
        [Required]
        public double Total { get; set; }
    }
}