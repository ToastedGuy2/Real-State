using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Generic;
//using Web.Models;

namespace Web.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IGenericService<Invoice> _invoiceService;
        private readonly UserManager<AppUser> _userManager;

        public InvoiceController(IInvoiceService invoiceService, UserManager<AppUser> userManager)
        {
            this._invoiceService = invoiceService;
            this._userManager = userManager;
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public IActionResult Admin()
        {
            return View(_invoiceService.GetAll());
        }
        [Authorize(Roles = "SuperAdmin,Customer")]
        public IActionResult Customer()
        {
            string customerId = _userManager.GetUserId(User);
            return View(_invoiceService.GetAll().Where(h => h.CustomerId == customerId));
        }

        [Authorize(Roles = "SuperAdmin,Admin,Customer")]
        public IActionResult Details(int id)
        {
            var invoice = _invoiceService.GetById(id);

            if (invoice == null)
            {
                return NotFound();
            }
            return View(invoice);
        }
    }
}