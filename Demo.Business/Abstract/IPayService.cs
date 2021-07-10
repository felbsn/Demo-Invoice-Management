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

    public class PaymentPredentials
    {
        // some important stuff
        public string CardId { get; set; }
        public int CV2 { get; set; }
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
