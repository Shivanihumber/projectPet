using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4_5.Models
{
    [Table("Pet")]
    public class Pet
    {
        public int PetId { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Category> Categories {get; set; }
        public int CategoryId { get; set; }
        public DateTime  Birthdate { get; set; }
        public string Gender { get; set; }
        public decimal Price { get; set; }
    }
}