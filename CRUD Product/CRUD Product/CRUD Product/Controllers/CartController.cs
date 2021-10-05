using CRUD_Product.Models;
using CRUD_Product.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CRUD_Product.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Cart()
        {
              if (Session["order"] == null)
              {
                  return RedirectToAction("Index", "Product");
              }
              var cart = new JavaScriptSerializer().Deserialize<List<Product>>((string)Session["order"]);
              return View(cart);
            
        }

        public ActionResult AddToCart(int Id)
        {
            if (Session["order"] == null)
            {
                Product p = new Product();
                Database db = new Database();
                p = db.Products.Get(Id);
                List<Product> products = new List<Product>();
                products.Add(p);
                string json = new JavaScriptSerializer().Serialize(products);
                Session["order"] = json;
                return RedirectToAction("Index", "Product");
            }

            else
            {
                var d = new JavaScriptSerializer().Deserialize<List<Product>>((string)Session["order"]);
                Product p = new Product();
                Database db = new Database();
                p = db.Products.Get(Id);
                d.Add(p);
                string json = new JavaScriptSerializer().Serialize(d);
                Session["order"] = json;
                return RedirectToAction("Index", "Product");
            }
        }
        public ActionResult CheckOut()
        {
            Database db = new Database();
            var cart = new JavaScriptSerializer().Deserialize<List<Product>>((string)Session["order"]);
            foreach (var product in cart)
            {
                Order order = new Order()
                {
                    OrderProductName = product.Name,
                    OrderProductPrice = product.Price
                };
                db.Orders.Create(order);
            }
            Session["order"] = null;
            return RedirectToAction("Index", "Product");
        }
    }
}