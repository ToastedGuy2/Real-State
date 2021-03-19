using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Generic;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly GenericService<House> houseService;
        private readonly GenericService<Service> serviceServiceX;

        public InvoiceController(GenericService<House> houseService, GenericService<Service> serviceServiceX)
        {
            this.houseService = houseService;
            this.serviceServiceX = serviceServiceX;
        }


        [HttpGet("{id}")]
        public ActionResult<InvoiceDto> GetInvoiceDto(int houseId, string date, int monthsToStay, IEnumerable<int> servicesId)
        {
            // TODO: Your code here
            var house = houseService.GetById(houseId);
            // if (house == null)
            // {
            //     return NotFound();
            // }
            var services = servicesId.Select(id => serviceServiceX.GetById(id));
            // var fromDate = DateTime.ParseExact(date, "MM.dd.yyyy", new CultureInfo("en-US"));
            var response = new InvoiceDto()
            {
                HouseId = house.HouseId,
                HousePrice = house.Price,
                From = date,
                MonthsToStay = monthsToStay,
                SelectedServices = services
            };

            return Ok(response);
        }

    }
}