using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.Extensions.Logging;
using Repositories.Context;
using Repositories.Generic;

namespace Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(FoodTownDbContext context) : base(context)
        {
        }
        public override IEnumerable<Brand> GetAll()
        {
            return _table.OrderBy(b => b.Name);
        }
        public IEnumerable<Brand> GetBrandsByCategoryId(int categoryId)
        {
            return _table
                         .Where(b => b.CategoryId == categoryId)
                         .OrderBy(b => b.Name)
                         .ToList();
        }
    }
}