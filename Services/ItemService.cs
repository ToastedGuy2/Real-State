using System;
using System.Collections.Generic;
using Entities;
using Microsoft.AspNetCore.Http;
using Repositories;
using Repositories.Generic;

namespace Services
{
    public class ItemService : IItemService
    {
        private readonly IGenericRepository<Item> _itemRepository;
        private readonly IFileService _fileService;

        public ItemService(IGenericRepository<Item> itemRepository, IFileService fileService)
        {
            this._itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
            this._fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }
        public IEnumerable<Item> GetAll()
        {
            return _itemRepository.GetAll();
        }

        public Item GetById(int id)
        {
            return _itemRepository.GetById(id);
        }

        public void Insert(Item item, IFormFile image)
        {
            var imageName = _fileService.UploadImage(image);
            item.ImageName = imageName;
            _itemRepository.Insert(item);

        }


        public void Update(Item item, IFormFile image)
        {
            throw new System.NotImplementedException();
        }
        public void Save()
        {
            _itemRepository.Save();
        }
    }
}