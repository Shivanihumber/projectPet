using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab4_5.Models
{
    [Table("Category")]
    public class Category
    {
       
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please Enter the Category Name")]
        public string CategoryName { get; set; }
    }
}