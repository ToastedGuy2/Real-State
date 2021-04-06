using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Generic;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateInvoiceController : ControllerBase
    {
        private readonly IHouseService houseService;
        private readonly IGenericService<Service> serviceServiceX;

        public GenerateInvoiceController(IHouseService houseService, IGenericService<Service> serviceServiceX)
        {
            this.houseService = houseService;
            this.serviceServiceX = serviceServiceX;
        }


        [HttpGet("")]
        public ActionResult<InvoiceDto> GenerateInvoiceDto([FromQuery] int houseId, [FromQuery] int monthsToStay, [FromQuery] IEnumerable<int> service)
        {
            // TODO: Your code here
            var house = houseService.GetById(houseId);
            if (house == null)
            {
                return NotFound();
            }
            var services = service.Select(id => serviceServiceX.GetById(id)).ToList();
            // var fromDate = DateTime.ParseExact(date, "MM.dd.yyyy", new CultureInfo("en-US"));
            var response = new InvoiceDto()
            {
                HouseId = house.HouseId,
                HousePrice = house.Price,
                MonthsToStay = monthsToStay,
                SelectedServices = services
            };

            return Ok(response);
        }

    }
}