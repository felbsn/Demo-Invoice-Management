using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Entities
{
    public class Subscription
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Address { get; set; }
        public bool Closed { get; set; }


        public int ClientId { get; set; }

        [Required]
        public virtual Client Client { get; set; }

        public virtual IList<Invoice> Invoices { get; set; } = new List<Invoice>();

    }
}
