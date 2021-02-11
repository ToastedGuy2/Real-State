using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using Repositories.Context;
using Services.Generic;
using Web.ViewModels.House;
using AutoMapper;
using Services;

namespace Web.Controllers
{
    public class HouseController : Controller
    {
        private readonly IHouseService _houseService;
        private readonly IGenericService<Province> _provinceService;
        private readonly IGenericService<Feature> _featureService;
        private readonly IMapper _autoMapper;
        private readonly IGenericService<Service> _servicexService;

        public HouseController(IHouseService houseService, IGenericService<Province> provinceService, IGenericService<Feature> featureService, IMapper autoMapper, IGenericService<Service> servicexService)
        {
            this._houseService = houseService;
            this._provinceService = provinceService;
            this._featureService = featureService;
            this._autoMapper = autoMapper;
            this._servicexService = servicexService;
        }

        // GET: House
        public IActionResult List()
        {
            return View(_houseService.GetAll());
        }

        // GET: House/Create
        public IActionResult Create()
        {
            var model = new AddHouseViewModel()
            {
                Provinces = new SelectList(_provinceService.GetAll(), "ProvinceId", "Name"),
                Features = _featureService.GetAll(),
                Services = _servicexService.GetAll()
            };
            return View(model);
        }

        // POST: House/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("HouseId,Name,Price,Bedrooms,Bathrooms,Size,ProvinceId,ImageUploaded,Description")] AddHouseViewModel model, IEnumerable<int> features, IEnumerable<int> services)
        {
            if (ModelState.IsValid)
            {
                var house = _autoMapper.Map<House>(model);
                var houseFeatures = features.Select(id => new HouseFeature() { FeatureId = id });
                foreach (var id in features)
                {
                    house.Features.Add(new HouseFeature() { FeatureId = id });
                }
                var houseServices = services.Select(id => new HouseService() { ServiceId = id });
                foreach (var id in services)
                {
                    house.Services.Add(new HouseService() { ServiceId = id });
                }
                _houseService.Insert(house, model.ImageUploaded);
                _houseService.Save();
                TempData["TransactionCompleted"] = "House added Sucessfully";
                return RedirectToAction(nameof(List));
            }

            model.Provinces = new SelectList(_provinceService.GetAll(), "ProvinceId", "Name");
            model.Features = _featureService.GetAll();
            model.SelectedFeatures = features.Select(id => new HouseFeature() { FeatureId = id });
            model.Services = _servicexService.GetAll();
            model.SelectedServices = services.Select(id => new HouseService() { ServiceId = id });
            return View(model);
        }

        // GET: House/Edit/5
        public IActionResult Edit(int? id)
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
            var model = _autoMapper.Map<UpdateHouseViewModel>(house);
            model.Provinces = new SelectList(_provinceService.GetAll(), "ProvinceId", "Name");
            model.Features = _featureService.GetAll();
            model.SelectedFeatures = house.Features;
            model.Services = _servicexService.GetAll();
            model.SelectedServices = house.Services;
            return View(model);
        }

        // // POST: House/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("HouseId,Name,Price,Bedrooms,Bathrooms,Size,ProvinceId,ImageUploaded,Description")] UpdateHouseViewModel model, IEnumerable<int> features, IEnumerable<int> services)
        {
            if (id != model.HouseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var house = _autoMapper.Map<House>(model);
                foreach (var featureId in features)
                {
                    house.Features.Add(new HouseFeature() { HouseId = model.HouseId, FeatureId = featureId });
                }
                var houseServices = services.Select(id => new HouseService() { ServiceId = id });
                foreach (var serviceId in services)
                {
                    house.Services.Add(new HouseService() { HouseId = model.HouseId, ServiceId = serviceId });
                }
                _houseService.Update(house, model.ImageUploaded);
                _houseService.Save();
                TempData["TransactionCompleted"] = "House edited Sucessfully";
                return RedirectToAction(nameof(List));
            }
            model.Provinces = new SelectList(_provinceService.GetAll(), "ProvinceId", "Name", model.ProvinceId);
            model.Features = _featureService.GetAll();
            model.SelectedFeatures = features.Select(id => new HouseFeature() { FeatureId = id });
            model.Services = _servicexService.GetAll();
            model.SelectedServices = services.Select(id => new HouseService() { ServiceId = id });
            return View(model);
        }
    }
}
