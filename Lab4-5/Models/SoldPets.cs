using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab4_5.Models
{
    [Table("SoldPets")]
    public class SoldPets
    {
        [Key]
        public int SoldPetsId { get; set; }
        public Category Category { get; set; }
     
        public int CategoryId { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public decimal Price { get; set; }
    }
}