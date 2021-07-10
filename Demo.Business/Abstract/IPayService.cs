using System;
using System.Collections.Generic;
using System.Text;
using Demo.Entities;

namespace Demo.Business.Abstract
{
    public interface IPayService
    {
        PaymentResult Pay(int invoiceId, PaymentPredentials paymentPredentials, PaymentMethod method, int managerId );
    }

    public struct PaymentPredentials
    {
        // some important stuff
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
