using System;
using System.Collections.Generic;
using Repositories;
using Repositories.Generic;

namespace Services.Generic
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _genericRepository;

        public GenericService(IGenericRepository<T> genericRepository)
        {
            _genericRepository = genericRepository ?? throw new ArgumentNullException(nameof(genericRepository));
        }

        public IEnumerable<T> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public T GetById(object id)
        {
            return _genericRepository.GetById(id);
        }

        public virtual void Insert(T obj)
        {
            _genericRepository.Insert(obj);
        }

        public virtual void Update(T obj)
        {
            _genericRepository.Update(obj);
        }

        public void Delete(object id)
        {
            _genericRepository.Delete(id);
        }

        public void Save()
        {
            _genericRepository.Save();
        }
    }
}