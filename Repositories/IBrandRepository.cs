using System.Collections.Generic;
using Entities;
using Repositories.Generic;

namespace Repositories
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        IEnumerable<Brand> GetBrandsByCategoryId(int categoryId);
    }
}