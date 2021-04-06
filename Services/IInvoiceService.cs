using System.Collections.Generic;
using Entities;
using Services.Generic;

namespace Services
{
    public interface IInvoiceService : IGenericService<Invoice>
    {
        void Insert(Invoice invoice, IEnumerable<int> servicesId);

    }
}