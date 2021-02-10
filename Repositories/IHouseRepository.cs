using Entities;
using Repositories.Generic;

namespace Repositories
{
    public interface IHouseRepository : IGenericRepository<House>
    {
        bool HouseExists(int houseId);
    }
}