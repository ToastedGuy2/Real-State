using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Generic;

namespace Repositories
{
    public class HouseRepository : GenericRepository<House>, IHouseRepository
    {
        public HouseRepository(RealStateDbContext context) : base(context)
        {
        }
        public override void Update(House obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            var houseFeaturesToDelete = _context.HouseFeatures.Where(hF => hF.HouseId == obj.HouseId).ToList();
            _context.HouseFeatures.RemoveRange(houseFeaturesToDelete);
            // Save();
            _context.HouseFeatures.AddRange(obj.Features);
            // Save();
            obj.Features = null;
            var houseServicesToDelete = _context.HouseServices.Where(hS => hS.HouseId == obj.HouseId).ToList();
            _context.HouseServices.RemoveRange(houseServicesToDelete);
            // Save();
            _context.HouseServices.AddRange(obj.Services);
            // Save();
            obj.Services = null;
            base.Update(obj);
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

        public bool HouseExists(int houseId)
        {
            return _context.Houses.Any(h => h.HouseId == houseId);
        }

        private IQueryable<House> GetAllEagerLoading()
        {
            return _context.Houses.
            Include(h => h.Province).
            Include(h => h.Features).
            Include(h => h.Services).
            OrderBy(h => h.Name);
        }
    }
}