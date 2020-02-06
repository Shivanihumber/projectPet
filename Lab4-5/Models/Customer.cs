using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4_5.Models
{
    [Table("Customer")]
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelephoneNo{ get; set; }
        public string  Email { get; set; }
    }
}