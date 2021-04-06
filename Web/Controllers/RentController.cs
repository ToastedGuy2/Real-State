using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Generic;
using Web.ViewModels.Rent;
//using Web.Models;

namespace Web.Controllers
{
    public class RentController : Controller
    {
        private readonly IHouseService _houseService;
        private readonly IGenericService<Province> _provinceService;
        private readonly IGenericService<Feature> _featureService;
        private readonly IGenericService<Service> _serviceService;
        private readonly IMapper _autoMapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IInvoiceService _InvoiceService;

        public RentController(IHouseService houseService, IGenericService<Province> provinceService, IGenericService<Feature> featureService, IGenericService<Service> serviceService, IMapper autoMapper, UserManager<AppUser> userManager, IInvoiceService invoiceService)
        {
            this._houseService = houseService;
            this._provinceService = provinceService;
            this._featureService = featureService;
            this._serviceService = serviceService;
            this._autoMapper = autoMapper;
            this._userManager = userManager;
            this._InvoiceService = invoiceService;
        }

        public async Task<IActionResult> List(string province = null)
        {
            await Task.Yield();
            var model = new RentListViewModel()
            {
                Houses = province == null ? _houseService.GetByAvailability().OrderBy(h => h.Price) : _houseService.GetAll().Where(h => h.Province.Name == province).OrderBy(h => h.Price),
                Features = _featureService.GetAll(),
                Provinces = _provinceService.GetAll(),
                ProvinceToCheck = province
            };

            return View(model);
        }
        [Authorize(Roles = "Customer,SuperAdmin")]
        public async Task<IActionResult> House(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = _houseService.GetById(id.Value);
            if (house == null)
            {
                return NotFound();
            }
            if (!house.IsItAvailable)
            {
                return RedirectToAction("NotAvailable", "Show");
            }

            var model = new InvoiceViewModel
            {
                HouseId = house.HouseId,
                Price = house.Price,
                ServicesToDisplay = house.Services.Select(s => s.Service).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult HouseAsync(InvoiceViewModel model, IEnumerable<int> service)
        {
            if (ModelState.IsValid)
            {
                var invoice = _autoMapper.Map<Invoice>(model);
                invoice.CustomerId = _userManager.GetUserId(User);
                _InvoiceService.Insert(invoice, service);
                _InvoiceService.Save();
                TempData["TransactionComplete"] = true;
                return RedirectToAction("Customer", "Invoice");
            }
            var house = _houseService.GetById(model.HouseId);
            var services = house.Services.Select(s => s.Service);
            model.ServicesToDisplay = services.ToList();
            return View(model);
        }

    }
}
