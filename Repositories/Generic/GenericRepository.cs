using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Context;

namespace Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public RealStateDbContext _context;
        public DbSet<T> _table;
        // private readonly ILogger _logger;

        // public GenericRepository(FoodTownDbContext context, ILogger<T> logger)
        // {
        //     this._context = context ?? throw new ArgumentNullException(nameof(context));
        //     this._logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        //     this._table = _context.Set<T>();
        // }
        public GenericRepository(RealStateDbContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            this._table = _context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public virtual T GetById(object id)
        {
            return _table.Find(id);
        }

        public virtual void Insert(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _table.Add(obj);
        }

        public virtual void Update(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _table.Update(obj);
        }

        public virtual void Delete(object id)
        {

            var entityToDelete = _table.Find(id);
            if (entityToDelete == null)
            {
                throw new ArgumentNullException(nameof(entityToDelete));
            }
            _table.Remove(entityToDelete);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}