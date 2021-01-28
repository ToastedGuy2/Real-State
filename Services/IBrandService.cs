using System.Collections.Generic;
using Entities;
using Services.Generic;

namespace Services
{
    public interface IBrandService : IGenericService<Brand>
    {
        IEnumerable<Brand> GetBrandsByCategoryId(int categoryId);
    }
}