using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.AspNetCore.Identity;
using Repositories.Generic;
using Services.Generic;

namespace Services
{
    public class InvoiceServiceX : GenericService<Invoice>, IInvoiceService
    {
        private readonly IHouseService _houseService;
        private readonly IGenericService<InvoiceService> _invoiceService;
        private readonly IGenericService<Service> _serviceService;
        private readonly UserManager<AppUser> _userManager;

        public InvoiceServiceX(IGenericRepository<Invoice> genericRepository, IHouseService houseService, IGenericService<InvoiceService> invoiceService, IGenericService<Service> serviceService) : base(genericRepository)
        {
            this._invoiceService = invoiceService;
            this._serviceService = serviceService;
            this._houseService = houseService;
        }

        public void Insert(Invoice invoice, IEnumerable<int> servicesId)
        {
            var house = _houseService.GetById(invoice.HouseId);
            invoice.HomeSubTotal = CalculateHomeSubTotal(invoice, house);
            var services = servicesId.Select(serviceId => _serviceService.GetById(serviceId));
            invoice.ServicesSubTotal = CalculateServicesSubTotal(services);
            invoice.SubTotal = CalculateSubTotal(invoice);
            invoice.Tax = CalculateTax(invoice);
            invoice.Total = CalculateTotal(invoice);
            base.Insert(invoice);
            base.Save();
            foreach (var service in services)
            {
                var invoiceService = new InvoiceService()
                {
                    InvoiceId = invoice.InvoiceId,
                    ServiceId = service.ServiceId
                };
                _invoiceService.Insert(invoiceService);
            }
            base.Save();
            house.IsItAvailable = false;
            _houseService.Update(house);
        }
        private double CalculateHomeSubTotal(Invoice invoice, House house)
        {
            return house.Price * invoice.Months;
        }
        private double CalculateServicesSubTotal(IEnumerable<Service> services)
        {
            return services.Sum(service => service.Price);
        }
        private double CalculateSubTotal(Invoice invoice)
        {
            return invoice.HomeSubTotal + invoice.ServicesSubTotal;
        }
        private double CalculateTax(Invoice invoice)
        {
            return invoice.SubTotal * 0.13;
        }
        private double CalculateTotal(Invoice invoice)
        {
            return invoice.SubTotal + invoice.Tax;
        }

    }
}