using Demo.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entities
{
    public abstract class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ClientNumber { get; set; }
        public string Password { get; set; }

        public virtual List<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
