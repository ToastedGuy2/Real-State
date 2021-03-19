using System.Globalization;
using System;
using System.Linq;
using System.Collections.Generic;
using Entities;

namespace Web.Models
{
    public class InvoiceDto
    {
        public int MonthsToStay { get; set; }
        public string From { get; set; }
        public string To { get => DateTime.ParseExact(From, "MM.dd.yyyy", new CultureInfo("en-US")).AddMonths(MonthsToStay).ToString("MM.dd.yyyy"); }
        public int HouseId { get; set; }
        public double HousePrice { get; set; }
        public IEnumerable<Service> SelectedServices { get; set; } = new List<Service>();
        public double RentSubTotal { get => HousePrice * MonthsToStay; }
        public double ServicesSubTotal { get => SelectedServices.Sum(s => s.Price); }
        public double SubTotal { get => RentSubTotal + ServicesSubTotal; }
        public double Tax { get => SubTotal * 0.13; }
        public double Total { get => SubTotal + Tax; }

    }
}