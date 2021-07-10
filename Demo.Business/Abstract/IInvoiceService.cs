using System;
using System.Collections.Generic;
using System.Text;
using Demo.Entities;

namespace Demo.Business.Abstract
{
    public interface IInvoiceService
    {
        IList<Invoice> GetList();
        IList<Invoice> GetListByClientId(int clientId);
        IList<Invoice> GetListBySubscriptionId(int subscriptionId);

        Invoice Update(Invoice invoice);
        Invoice Find(int id);
    }
}
