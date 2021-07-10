using Demo.Business.Abstract;
using Demo.DataAccess.Abstract;
using Demo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Business.Concrete
{
    public class InvoiceManager : IInvoiceService
    {
        IInvoiceRepository _invoices;

        public InvoiceManager(IInvoiceRepository invoices)
        {
            _invoices = invoices;
        }

        public Invoice Find(int id)
        {
            return _invoices.Get(invoice => invoice.Id == id);
        }

        public IList<Invoice> GetList()
        {
            return _invoices.GetList();
        }
        public IList<Invoice> GetListByClientId(int clientId)
        {
            return _invoices.GetList(invoice => invoice.Subscription.Client.Id == clientId);
        }

        public IList<Invoice> GetListBySubscriptionId(int subscriptionId)
        {
            return _invoices.GetList(invoice => invoice.Subscription.Id == subscriptionId);
        }

        public Invoice Update(Invoice invoice)
        {
            return _invoices.Update(invoice);
        }
    }
}
