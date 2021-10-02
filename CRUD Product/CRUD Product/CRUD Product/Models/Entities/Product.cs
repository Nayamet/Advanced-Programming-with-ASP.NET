using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_Product.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*Product name required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "*Product quantity required")]
        public int Qty { get; set; }
        [Required(ErrorMessage = "*Product price required")]
        public float Price { get; set; }
        public string Description { get; set; }
    }
}