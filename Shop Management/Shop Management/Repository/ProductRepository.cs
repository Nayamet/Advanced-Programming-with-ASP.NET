using Shop_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Management.Repository
{
    public class ProductRepository
    {
        static EcommerceEntities db;
        static ProductRepository()
        {
            db = new EcommerceEntities();
        }

        public static ProductModel Get(int Id)
        {
            var p = (from pr in db.Products
                     where pr.ProductId == Id
                     select pr).FirstOrDefault();
            return new ProductModel()
            {
                Id = p.ProductId,
                Name = p.ProductName,
                Price = p.ProductPerUnitPrice,
                Description = p.ProductDescription
            };
        }

        public static List<ProductModel> GetAll()
        {
            var products = new List<ProductModel>();
            foreach (var pr in db.Products)
            {
                var product = new ProductModel()
                {
                    Id = pr.ProductId,
                    Name = pr.ProductName,
                    Price = pr.ProductPerUnitPrice,
                    Description = pr.ProductDescription
                };
                products.Add(product);
            }
            return products;
        }
    }
}