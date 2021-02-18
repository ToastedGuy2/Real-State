using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services;
using Web.Dto;
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
        public async Task<ActionResult<IEnumerable<HouseDto>>> GetHouses()
        {
            // TODO: Your code here
            await Task.Yield();
            var houseEntities = _houseService.GetAll();
            var response = _mapper.Map<IEnumerable<HouseDto>>(houseEntities);
            return Ok(response);
        }

    }
}