using Demo.Business.Abstract;
using Demo.DataAccess.Abstract;
using Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Business.Concrete
{
    public class SubscriptionManager : ISubscriptionService
    {
        ISubscriptionRepository _subs;

        public SubscriptionManager(ISubscriptionRepository subs)
        {
            _subs = subs;
        }

        public SubscriptionCloseResult Close(Subscription subscription)
        {
            if (subscription.Invoices.Any(invoice => invoice.IsPaid == false))
            {
                return SubscriptionCloseResult.CantCloseDueUnpaidInvoices;
            }else
            {
                subscription.Closed = true;
                _subs.Update(subscription);
                return SubscriptionCloseResult.Success;
            }
        }


        public IList<Subscription> Get()
        {
            return _subs.GetList();
        }

        public IList<Subscription> Get(Client client)
        {
            return _subs.GetList();
        }


        public Subscription Create(Subscription subscription, Client client)
        {
            subscription.Client = client;
            return _subs.Update(subscription);
        }

        public Subscription Open(Subscription subscription)
        {
            subscription.Closed = false;
            return _subs.Update(subscription);
        }

        public Subscription Update(Subscription subscription)
        {
            return _subs.Update(subscription);
        }

        public Subscription Find(int subscriptionId)
        {
            return _subs.Get(s => s.Id == subscriptionId);
        }
    }
}
