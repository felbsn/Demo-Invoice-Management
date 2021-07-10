using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Entities
{
    public enum PaymentMethod
    {
        ByClient,
        ByManager
    }

    public class Payment
    {
        [Key,  DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Value { get; set; }


        public DateTime TransactionDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public virtual Manager Manager { get; set; }

        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
