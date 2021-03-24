using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Generic;
using Web.ViewModels.Rent;
//using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles = "Customer,SuperAdmin")]
    public class RentController : Controller
    {
        private readonly IHouseService _houseService;
        private readonly IGenericService<Province> _provinceService;
        private readonly IGenericService<Feature> _featureService;
        private readonly IGenericService<Service> _serviceService;
        private readonly IMapper _autoMapper;
        public RentController(IHouseService houseService, IGenericService<Province> provinceService, IGenericService<Feature> featureService, IGenericService<Service> serviceService, IMapper autoMapper)
        {
            this._houseService = houseService;
            this._provinceService = provinceService;
            this._featureService = featureService;
            this._serviceService = serviceService;
            _autoMapper = autoMapper;
        }

        public async Task<IActionResult> List(string province = null)
        {
            await Task.Yield();
            var model = new RentListViewModel()
            {
                Houses = province == null ? _houseService.GetAll().OrderBy(h => h.Price) : _houseService.GetAll().Where(h => h.Province.Name == province).OrderBy(h => h.Price),
                Features = _featureService.GetAll(),
                Provinces = _provinceService.GetAll(),
                ProvinceToCheck = province
            };

            return View(model);
        }
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
            var houseServices = _serviceService.GetAll().Where(s => house.Services.Any(hs => hs.ServiceId == s.ServiceId));
            var model = new RentHouseViewModel
            {
                House = house,
                ServicesToDisplay = houseServices.ToList()
            };
            return View(model);
        }

    }
}