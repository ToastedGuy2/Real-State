using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.ViewModels.Item;
using Web.Helpers;
using AutoMapper;
using Services.Generic;

namespace Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IBrandService _brandService;
        private readonly IGenericService<Category> _categoryService;
        private readonly IMapper _autoMapper;

        public ItemController(IItemService itemService, IBrandService brandService, IGenericService<Category> categoryService, IMapper autoMapper)
        {
            this._categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this._autoMapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
            this._brandService = brandService ?? throw new ArgumentNullException(nameof(brandService));
            this._itemService = itemService ?? throw new ArgumentNullException(nameof(itemService));
        }
        [HttpGet]
        public IActionResult List()
        {
            return View(_itemService.GetAll());
        }
        [HttpGet]
        public IActionResult Add()
        {
            var categories = _categoryService.GetAll();
            var brands = _brandService.GetBrandsByCategoryId(categories.FirstOrDefault().CategoryId);

            var model = new AddItemViewModel()
            {
                Brands = brands.ToSelectList(),
                Categories = categories.ToSelectList()
            };
            return PartialView("_Add", model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                var itemToInsert = _autoMapper.Map<Item>(model);
                _itemService.Insert(itemToInsert, model.ImageUploaded);
                _itemService.Save();
                return new JsonResult(new { IsValid = true });
            }
            var categories = _categoryService.GetAll();
            var brands = _brandService.GetBrandsByCategoryId(categories.FirstOrDefault().CategoryId);
            model.Brands = brands.ToSelectList();
            model.Categories = categories.ToSelectList();
            var partialView = await this.RenderViewAsync("_add", model, true);
            return new JsonResult(new { IsValid = false, Html = partialView });
        }



    }
}