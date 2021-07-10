using Demo.DataAccess.Abstract;
using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Demo.DataAccess.Concrete.Ef
{
    public class SubscriptionRepository : EfEntityRepositoryBase<Subscription,DemoContext> , ISubscriptionRepository
    {
        public Subscription Get(Expression<Func<Subscription, bool>> filter)
        {
            using (var context = new DemoContext())
            {
                return context.Set<Subscription>().Include(model => model.Invoices).SingleOrDefault(filter);
            }
        }
        public IList<Subscription> GetList(Expression<Func<Subscription, bool>> filter = null)
        {
            using (var context = new DemoContext())
            {
                return filter == null
                    ? context.Set<Subscription>().Include(model => model.Invoices).ToList()
                    : context.Set<Subscription>().Include(model => model.Invoices).Where(filter).ToList();
            }
        }
    }
}
