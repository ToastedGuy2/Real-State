using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Context;
using Repositories.Generic;

namespace Repositories
{
    public class ItemRepository : GenericRepository<Item>, IGenericRepository<Item>
    {
        public ItemRepository(FoodTownDbContext context) : base(context)
        {
        }
        public override IEnumerable<Item> GetAll()
        {
            return GetAllEagerLoading().ToList();
        }

        public override Item GetById(object id)
        {
            return GetAllEagerLoading().
                   FirstOrDefault(i => i.ItemId == ((int)id));
        }
        private IQueryable<Item> GetAllEagerLoading()
        {
            return _context.Items.
            Include(i => i.Category).
            Include(i => i.Brand).OrderBy(i => i.Name);
        }
    }
}