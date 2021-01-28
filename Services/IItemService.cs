using System.Collections.Generic;
using Entities;
using Microsoft.AspNetCore.Http;

namespace Services
{
    public interface IItemService
    {
        void Insert(Item item, IFormFile image);
        void Update(Item item, IFormFile image);
        Item GetById(int id);
        IEnumerable<Item> GetAll();
        void Save();
    }
}