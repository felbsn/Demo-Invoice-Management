using Demo.DataAccess.Abstract;
using Demo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.DataAccess.Concrete.Ef
{
    public class InvoiceRepository : EfEntityRepositoryBase<Invoice,DemoContext> ,IInvoiceRepository
    {

    }
}
