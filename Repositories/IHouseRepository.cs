using System.Collections.Generic;
using Entities;
using Repositories.Generic;

namespace Repositories
{
    public interface IHouseRepository : IGenericRepository<House>
    {
        bool HouseExists(int houseId);
        IEnumerable<House> GetByAvailability(bool availability = true);
    }
}