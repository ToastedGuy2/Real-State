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

        public HouseController(IHouseService houseService, IGenericService<Province> provinceService, IGenericService<Feature> featureService, IMapper autoMapper)
        {
            this._houseService = houseService;
            this._provinceService = provinceService;
            this._featureService = featureService;
            this._autoMapper = autoMapper;
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
                Features = _featureService.GetAll()
            };
            return View(model);
        }

        // POST: House/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddHouseViewModel model, IEnumerable<int> features)
        {
            if (ModelState.IsValid)
            {
                var house = _autoMapper.Map<House>(model);
                var houseFeatures = features.Select(id => new HouseFeature() { FeatureId = id });
                foreach (var id in features)
                {
                    house.Features.Add(new HouseFeature() { FeatureId = id });
                }
                _houseService.Insert(house, model.ImageUploaded);
                _houseService.Save();
                return RedirectToAction(nameof(List));
            }

            model.Provinces = new SelectList(_provinceService.GetAll(), "ProvinceId", "Name");
            model.Features = _featureService.GetAll();
            return View(model);
        }

        // // GET: House/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var house = await _context.Houses.FindAsync(id);
        //     if (house == null)
        //     {
        //         return NotFound();
        //     }
        //     ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "Name", house.ProvinceId);
        //     return View(house);
        // }

        // // POST: House/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("HouseId,Name,Price,Description,Bathrooms,Bedrooms,Size,IsItAvailable,ProvinceId,ImageName")] House house)
        // {
        //     if (id != house.HouseId)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(house);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!HouseExists(house.HouseId))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["ProvinceId"] = new SelectList(_context.Provinces, "ProvinceId", "Name", house.ProvinceId);
        //     return View(house);
        // }

        // private bool HouseExists(int id)
        // {
        //     return _context.Houses.Any(e => e.HouseId == id);
        // }
    }
}
