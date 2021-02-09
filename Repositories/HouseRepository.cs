using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Generic;

namespace Repositories
{
    public class HouseRepository : GenericRepository<House>, IGenericRepository<House>
    {
        public HouseRepository(RealStateDbContext context) : base(context)
        {
        }
        public override IEnumerable<House> GetAll()
        {
            return GetAllEagerLoading().ToList();
        }

        public override House GetById(object id)
        {
            return GetAllEagerLoading().
                   FirstOrDefault(h => h.HouseId == ((int)id));
        }
        private IQueryable<House> GetAllEagerLoading()
        {
            return _context.Houses.
            Include(h => h.Province).
            Include(h => h.Features).OrderBy(i => i.Name);
        }
    }
}