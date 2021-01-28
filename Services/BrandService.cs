using System.Collections.Generic;
using Entities;
using Repositories;
using Repositories.Generic;
using Services.Generic;

namespace Services
{
    public class BrandService : GenericService<Brand>, IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IGenericRepository<Brand> genericRepository, IBrandRepository brandRepository) : base(genericRepository)
        {
            this._brandRepository = brandRepository;
        }
        public IEnumerable<Brand> GetBrandsByCategoryId(int categoryId)
        {
            return _brandRepository.GetBrandsByCategoryId(categoryId);
        }
    }
}