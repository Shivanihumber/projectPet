using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4_5.Models
{
    [Table("Sales")]
    public class Sales
    {
        public int SalesId { get; set; }
       // public Customer Customer { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public int CustomerId { get; set; }
       // public Pet Pet { get; set; }
        public IEnumerable<Pet> Pets { get; set; }
        public int PetId { get; set; }
        public DateTime DateOFSale { get; set; }
    }
}