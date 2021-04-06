using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Web.Models;

namespace Web.Controllers
{
    public class ShowController : Controller
    {
        public ShowController()
        {
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult NotAvailable()
        {
            return View();
        }
        public IActionResult NotAuthorize()
        {
            return View();
        }
    }
}
