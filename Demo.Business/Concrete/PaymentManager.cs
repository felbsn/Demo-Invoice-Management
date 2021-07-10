using Demo.Business.Abstract;
using Demo.DataAccess.Abstract;
using Demo.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Demo.Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentRepository _payments;
 

        public PaymentManager(IPaymentRepository payments )
        {
            _payments = payments;
        }

        public IList<Payment> GetList()
        {
            return _payments.GetList();
        }
    }
}
