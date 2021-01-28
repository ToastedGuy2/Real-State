using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Generic;
using Web.Models;
//using Web.Models;

namespace Web.Api
{
    [Route("api/{categoryId}/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IGenericService<Category> _categoryService;
        private readonly IMapper _autoMapper;
        public BrandController(IGenericService<Category> categoryService, IBrandService brandService, IMapper autoMapper)
        {
            this._autoMapper = autoMapper;
            this._categoryService = categoryService;
            this._brandService = brandService;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Brand>> GetBrands(int categoryId)
        {
            var category = _categoryService.GetById(categoryId);
            if (category == null)
            {
                return NotFound();
            }
            var brandEntities = _brandService.GetBrandsByCategoryId(categoryId);
            var responseBody = _autoMapper.Map<IEnumerable<BrandDto>>(brandEntities);
            return Ok(responseBody);
        }

        [HttpGet("{id}")]
        public ActionResult<Brand> GetBrandById(int id)
        {
            var text = "";
            for (int i = 0; i < 10000000; i++)
            {
                text += "";
            }
            return null;
        }

        [HttpPost("")]
        public ActionResult<Brand> PostBrand(Brand model)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutBrand(int id, Brand model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Brand> DeleteBrandById(int id)
        {
            return null;
        }
    }
}