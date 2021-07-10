using Demo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataAccess.Abstract
{
    public interface IInvoiceRepository : IEntityRepository<Invoice>
    {
    }
}
