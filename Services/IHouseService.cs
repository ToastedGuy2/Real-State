using System.Collections.Generic;
using Entities;
using Microsoft.AspNetCore.Http;

namespace Services
{
    public interface IHouseService
    {
        void Insert(House house, IFormFile image);
        void Update(House house, IFormFile image = null);
        House GetById(int id);
        IEnumerable<House> GetAll();
        void Save();
        bool HouseExists(int houseId);
        IEnumerable<House> GetByAvailability(bool availability = true);
    }
}