using CRUD_Product.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD_Product.Models.Tables
{
    public class Orders
    {
        SqlConnection conn;

        public Orders(SqlConnection conn)
        {
            this.conn = conn;
        }

        public void Create(Order o)
        {
            conn.Open();
            string query = string.Format("insert into [Order] values ('{0}', {1})", o.OrderProductName, o.OrderProductPrice);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}