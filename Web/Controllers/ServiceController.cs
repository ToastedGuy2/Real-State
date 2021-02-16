using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using Repositories.Context;
using Services;
using Services.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ServiceController : Controller
    {
        private readonly IGenericService<Service> _serviceService;

        public ServiceController(IGenericService<Service> serviceService)
        {
            this._serviceService = serviceService;
        }

        // GET: House
        public IActionResult List()
        {
            return View(_serviceService.GetAll());
        }

        // GET: House/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: House/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Price,Description")] Service service)
        {
            if (ModelState.IsValid)
            {
                _serviceService.Insert(service);
                _serviceService.Save();
                TempData["TransactionCompleted"] = "House added Sucessfully";
                return RedirectToAction(nameof(List));
            }
            return View(service);
        }

        // GET: House/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var service = _serviceService.GetById(id.Value);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        // // POST: House/Edit/5
        // // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ServiceId,Name,Price,Description")] Service service)
        {
            if (id != service.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _serviceService.Update(service);
                _serviceService.Save();
                TempData["TransactionCompleted"] = "House edited Sucessfully";
                return RedirectToAction(nameof(List));
            }
            return View(service);
        }

    }
}
