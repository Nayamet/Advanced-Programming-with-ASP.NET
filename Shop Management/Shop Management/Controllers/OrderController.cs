using Shop_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Shop_Management.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        [Authorize]
        public ActionResult CheckOut()
        {
            var products = new JavaScriptSerializer().Deserialize<List<ProductModel>>((string)Session["cart"]);
            int CustomerId = int.Parse(HttpContext.User.Identity.Name.ToString());
            float totalPrice = 0;
            foreach (var p in products)
            {
                totalPrice = (float)p.Price + totalPrice;
            }
            var db = new EcommerceEntities();
            Order o = new Order()
            {
                CustomerId= CustomerId,
                
                Status = "Ordered"
            };

            db.Orders.Add(o);
            db.SaveChanges();


            foreach (var p in products)
            {
                OrderDetail od = new OrderDetail()
                {
                    OrderId = o.OrderId,
                    ProductId = p.Id,
                    Qty = 1,
                    
                };

                db.OrderDetails.Add(od);
                db.SaveChanges();
            }
            Session.Remove("Cart");
            return RedirectToAction("CustomerProduct", "Product");
        }

        public ActionResult ShowOrders()
        {
            var db = new EcommerceEntities();
            int customerId = int.Parse(HttpContext.User.Identity.Name.ToString());
            var orders = (from o in db.Orders
                          where o.CustomerId == customerId
                          select o).ToList();

            List<OrderModel> om = new List<OrderModel>();
            foreach (var o in orders)
            {
                OrderModel ormo = new OrderModel()
                {
                    Id = o.OrderId,
                    
                    Status = o.Status
                };
                om.Add(ormo);
            }
            return View(om);
        }

        public ActionResult OrderDetail(int Id)
        {
            var db = new EcommerceEntities();
            var odetail = (from od in db.OrderDetails
                           where od.OrderId == Id
                           select od).ToList();
            List<OrderDetailModel> odm = new List<OrderDetailModel>();
            foreach (var od in odetail)
            {
                OrderDetailModel o = new OrderDetailModel()
                {
                    FK_Orders_Id = od.OrderId,
                    FK_Products_Id = od.ProductId,
                    Quantity = od.Qty,
                    UnitPrice = od.UnitPrice
                };
                odm.Add(o);
            }
            return View(odm);
        }
    }
}