using Demo.Business.Abstract;
using Demo.DataAccess.Abstract;
using Demo.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Demo.Business.Concrete
{
    public class PayManager : IPayService
    {
        IPaymentRepository _payments;
        IInvoiceRepository _invoices;
        IManagerRepository _managers;

        public PayManager(IPaymentRepository payments, IInvoiceRepository invoices, IManagerRepository managers)
        {
            _payments = payments;
            _invoices = invoices;
            _managers = managers;
        }

        public PaymentResult Pay(int invoiceId , PaymentPredentials paymentPredentials, PaymentMethod method , int id = 0)
        {
 
            Manager manager = null;
            if (method == PaymentMethod.ByManager)
                manager = _managers.Get(m => m.Id == id);

            var invoice = _invoices.Get(item => item.Id == invoiceId);
            if (invoice != null && !invoice.IsPaid)
            {
                using (var scope = new TransactionScope())
                {
                    // create new payment
                    var payment = new Payment()
                    {
                        Value = invoice.Value,
                        Invoice = invoice,
                        TransactionDate = DateTime.Now,
                        PaymentMethod = method,
                        Manager = manager
                    };


                    // add to database
                    payment = _payments.Add(payment);

                   //throw new Exception("asd");

                    // some real cash transfer method ??
                    // maybe add this to some provision table before ??
                    // .....

                    // update invoice
                    invoice.IsPaid = true;
                    _invoices.Update(invoice);

                    // complete transaction
                    scope.Complete();

                    return new PaymentResult()
                    {
                        Status = PaymentStatus.Success,
                        Payment = payment
                    };
                 }
            }
            else
            {
                PaymentStatus status;
                if (invoice == null)
                {
                    status = PaymentStatus.InvalidInvoice;
                }
                else
                if(invoice.IsPaid)
                {
                    status = PaymentStatus.AlreadyPaid;
                }else
                {
                    status = PaymentStatus.OtherError;
                }
             
                return new PaymentResult()
                {
                    Status = status,
                    Payment = null
                };
            }
     

            
        }
    }
}
