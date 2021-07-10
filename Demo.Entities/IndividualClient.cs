using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Entities
{
    public class IndividualClient : Client
    {
        public string Job { get; set; }
        public string IdentityNo { get; set; }
    }
}
