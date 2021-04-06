using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services;
using Web.Models;
//using Web.Models;

namespace Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly IHouseService _houseService;
        private readonly IMapper _mapper;
        public HousesController(IHouseService houseService, IMapper mapper)
        {
            _houseService = houseService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<HouseDto>> GetHouses()
        {
            var houseEntities = _houseService.GetAll();
            var response = _mapper.Map<IEnumerable<HouseDto>>(houseEntities);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public ActionResult<HouseDto> GetHouse(int id)
        {
            var house = _houseService.GetById(id);
            if (house == null)
            {
                return NotFound();
            }
            var response = _mapper.Map<HouseDto>(house);
            return Ok(response);
        }

    }
}