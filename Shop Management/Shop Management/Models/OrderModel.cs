using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Management.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public Nullable<double> Price { get; set; }
        public string Status { get; set; }
    }
}