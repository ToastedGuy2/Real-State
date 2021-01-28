using System.Collections.Generic;
using System.Linq;
using Entities;
using Repositories.Context;
using Repositories.Generic;

namespace Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(FoodTownDbContext context) : base(context)
        {
        }

        public override IEnumerable<Category> GetAll()
        {
            return _table.OrderBy(c => c.Name).ToList();
        }
    }
}