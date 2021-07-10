using System;
using System.Collections.Generic;
using System.Text;
using Demo.Entities;

namespace Demo.Business.Abstract
{
    public interface IPaymentService
    {
        IList<Payment> GetList();
    }
}
