using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Entities;

namespace Web.ViewModels.Rent
{
    public class InvoiceViewModel
    {
        public int HouseId { get; set; }
        public double Price { get; set; }
        [Display(Name = "From")]
        [Required(ErrorMessage = "When do you want to start living here????")]
        public string From { get; set; }
        [Display(Name = "Months to Stay")]
        [Required(ErrorMessage = "How long will you stay here???")]
        public int Months { get; set; } = 1;
        [Display(Name = "To")]
        public string To { get; set; } = DateTime.Now.AddMonths(1).ToString("MM.dd.yyyy");
        public ICollection<Service> ServicesToDisplay { get; set; } = new List<Service>();
        public ICollection<Service> SelectedServices { get; set; } = new List<Service>();
        public double HomeSubTotal { get => Price * Months; set => this.HomeSubTotal = value; }
        public double ServicesSubTotal { get => SelectedServices.Sum(s => s.Price); set => this.ServicesSubTotal = value; }
        public double SubTotal { get => HomeSubTotal + ServicesSubTotal; set => this.SubTotal = value; }
        public double Tax { get => SubTotal * 0.13; set => this.Tax = value; }
        public double Total { get => SubTotal + Tax; set => this.Total = value; }
    }
}