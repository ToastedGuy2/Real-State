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
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;
        public ItemController(IItemService itemService, IMapper mapper)
        {
            this._mapper = mapper;
            this._itemService = itemService;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<ItemDto>> GetItemDtos()
        {
            var items = _itemService.GetAll();
            var itemsDtos = _mapper.Map<IEnumerable<ItemDto>>(items);
            return Ok(itemsDtos.OrderByDescending(i => i.Id));
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItemDtoById(int id)
        {
            return null;
        }

        [HttpPost("")]
        public ActionResult<ItemDto> PostItemDto(ItemDto model)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutItemDto(int id, ItemDto model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<ItemDto> DeleteItemDtoById(int id)
        {
            return null;
        }
    }
}