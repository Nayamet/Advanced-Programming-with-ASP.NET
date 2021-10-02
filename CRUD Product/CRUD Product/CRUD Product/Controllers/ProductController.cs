using CRUD_Product.Models;
using CRUD_Product.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_Product.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {

            Database db = new Database();
            var products=db.Products.Get();
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if(ModelState.IsValid)
            {

                Database db = new Database();
                db.Products.Create(p);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
                Database db = new Database();
                var s=db.Products.Get(id);
                return View(s);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {

                Database db = new Database();
                db.Products.Edit(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public ActionResult Delete(int id)
        {
            Database db = new Database();
            db.Products.Delete(id);
            return RedirectToAction("Index");
        }



    }
}