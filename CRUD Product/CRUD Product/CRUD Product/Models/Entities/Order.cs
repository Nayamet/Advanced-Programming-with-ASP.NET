using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Product.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderProductName { get; set; }
        public float OrderProductPrice { get; set; }
    }
}