using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Demo.Entities
{
    public class CorporateClient : Client 
    {
        public  string TaxNo{ get; set; }
        public string OfficeAddress { get; set; }
    }
}
