using Shop_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Shop_Management.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Customer c)
        {
            var db = new EcommerceEntities();
            var user = (from u in db.Customers
                        where u.Phone == c.Phone && u.Password == c.Password
                        select u).FirstOrDefault();
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                Session["UserType"] = "customer";
                return RedirectToAction("CustomerProduct", "Product");
            }

            return View();
        }
    }
}