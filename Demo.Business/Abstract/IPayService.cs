using System;
using System.Collections.Generic;
using System.Text;
using Demo.Entities;

namespace Demo.Business.Abstract
{
    public interface IPayService
    {
        PaymentResult Pay(int invoiceId, PaymentMethod method, int managerId );
    }

    public enum PaymentStatus
    {
        Success,
        AlreadyPaid,
        InvalidInvoice,
        OtherError,
        // ... 
        // ...
    }

    public class PaymentResult
    {
        public PaymentStatus Status { get; set; }
        public Payment Payment { get; set; }
    }
}
