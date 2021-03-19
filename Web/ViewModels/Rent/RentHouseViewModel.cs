using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities;

namespace Web.ViewModels.Rent
{
    public class RentHouseViewModel
    {
        public Entities.House House { get; set; }
        [Display(Name = "From")]
        [Required(ErrorMessage = "When do you want to start living here????")]
        public string From { get; set; }
        [Display(Name = "Months to Stay")]
        [Required(ErrorMessage = "How long will you stay here???")]
        public int Months { get; set; } = 1;
        [Display(Name = "To")]
        [DisplayFormat()]
        public string To { get => DateTime.Now.AddMonths(Months).ToString("MM.dd.yyyy"); }
        [Display(Name = "Sub Total")]
        public double SubTotal { get => House.Price * Months; }
        public double Iva { get => House.Price * 0.13; }
        public double Total { get => SubTotal + Iva; }
        public ICollection<Service> ServicesToDisplay { get; set; } = new List<Service>();
    }
}