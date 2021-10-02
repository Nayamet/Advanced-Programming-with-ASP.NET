using CRUD_Product.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD_Product.Models.Tables
{
    public class Products
    {
        public SqlConnection conn;
        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }

        public void Create(Product p)
        {
            conn.Open();
            string query = String.Format("insert into Products values ('{0}','{1}','{2}','{3}')", p.Name, p.Qty, p.Price, p.Description);
            SqlCommand cmd = new SqlCommand(query, conn);
            var r = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public List<Product> Get()
        {
            conn.Open();
            string query = "Select * from Products";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    Qty = reader.GetInt32(reader.GetOrdinal("qty")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("price")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };
                products.Add(p);
            }
            conn.Close();
            return products;
        }
        public Product Get(int id)
        {
            conn.Open();
            string query =String.Format("Select * from Products where id={0}",id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Product p = null;
            while(reader.Read())
            {
                p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("id")),
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    Qty = reader.GetInt32(reader.GetOrdinal("qty")),
                    Price = (float)reader.GetDouble(reader.GetOrdinal("price")),
                    Description = reader.GetString(reader.GetOrdinal("Description"))
                };

            }
            conn.Close();
            return p;

        }

        public void Edit(Product p)
        {
            conn.Open();
            string query = string.Format("UPDATE Products SET name = '{0}', qty = '{1}', price = '{2}', description = '{3}' where id = {4}",p.Name,p.Qty,p.Price,p.Description,p.Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            var r = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(int id)
        {
            conn.Open();
            string query = String.Format("DELETE FROM Products WHERE id = '{0}'",id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}