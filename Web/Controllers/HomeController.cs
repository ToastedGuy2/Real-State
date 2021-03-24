using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Generic;
using Web.ViewModels.Home;
// using Web.Models;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IGenericService<Province> _provinceService;

        public HomeController(IGenericService<Province> provincesService)
        {
            this._provinceService = provincesService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var selectProvinces = new SelectList(_provinceService.GetAll().OrderBy(p => p.Name), "Name", "Name");
            var model = new IndexViewModel
            {
                Provinces = selectProvinces
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(IndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("List", "Rent", new { province = model.SelectedProvince });
            }
            var selectProvinces = new SelectList(_provinceService.GetAll().OrderBy(p => p.Name), "Name", "Name");
            model.Provinces = selectProvinces;
            return View(model);
        }
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
    }
}