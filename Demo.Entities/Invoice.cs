using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entities
{
    public class Invoice
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Value { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ExpireTime { get; set; }

        public bool IsPaid { get; set; }

        
        public int SubscriptionId { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
