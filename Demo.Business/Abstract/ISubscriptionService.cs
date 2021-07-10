using System;
using System.Collections.Generic;
using System.Text;
using Demo.Entities;

namespace Demo.Business.Abstract
{
    public interface ISubscriptionService
    {
        public IList<Subscription> Get();
        public IList<Subscription> Get(Client client);
        public Subscription Update(Subscription subscription);

        public Subscription Create(Subscription subscription, Client client);
        public Subscription Open(Subscription subscription);
        public SubscriptionCloseResult Close(Subscription subscription);
        Subscription Find(int subscriptionId);
    }

    public enum SubscriptionCloseResult
    {
        Success,
        CantCloseDueUnpaidInvoices,
        Other,
    }
}
