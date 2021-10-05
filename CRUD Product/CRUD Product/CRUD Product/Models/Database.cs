using CRUD_Product.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD_Product.Models
{
    public class Database
    {
        SqlConnection conn;
        public Products Products { get; set; }
        public Orders Orders { get; set; }
        public Database()
        {
            string connString = @"Server=DISHAN\SQLEXPRESS;Database=labTask;User Id=sa;Password=Nayamet@19392";
            conn = new SqlConnection(connString);
            Products = new Products(conn);
            Orders = new Orders(conn);
        }
    }
}