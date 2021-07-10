using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Entities
{
    [Flags]
    public enum AccessLevel
    {
        Readonly = 1 << 0,
        Payment  = 1 << 1,
        Subscription = 1 << 2,
    }

    public class Manager
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public AccessLevel Level { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
