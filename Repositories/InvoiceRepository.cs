using System.Collections.Generic;
using System.Linq;
using Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Entities;
using Repositories.Generic;

namespace Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice>
    {
        public InvoiceRepository(RealStateDbContext context) : base(context)
        {
        }
        public override IEnumerable<Invoice> GetAll()
        {
            return GetAllEagerLoading().ToList();
        }

        public override Invoice GetById(object id)
        {
            return GetAllEagerLoading().
                   FirstOrDefault(i => i.InvoiceId == ((int)id));
        }

        private IQueryable<Invoice> GetAllEagerLoading()
        {
            return _context.Invoices.
            Include(i => i.Services).
            ThenInclude(iV => iV.Service).
            Include(i => i.House).
            Include(i => i.Customer).
            OrderByDescending(i => i.Date);
        }
    }
}