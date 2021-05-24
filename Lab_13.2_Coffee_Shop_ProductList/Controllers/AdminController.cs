using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using Lab_13._2_Coffee_Shop_ProductList.Models;

namespace Lab_13._2_Coffee_Shop_ProductList.Controllers
{
    public class AdminController : Controller
    {
        static MySqlConnection db = new MySqlConnection("Server=localhost;Database=Coffeehouse;Uid=root;Password=abc123");

        public IActionResult Index()
        {
            List<Product> menu = db.GetAll<Product>().ToList();
            return View(menu);
        }

        public IActionResult Admin(int id)
        {
            Product menu = db.Get<Product>(id);
            if (menu == null)
            {
                return Content("No product was found with that id");
            }
            return View(menu);
        }

        public IActionResult AddForm()
        {
            return View();
        }

        public IActionResult Add(Product menu)
        {
            db.Insert(menu);
            return RedirectToAction("Index");
        }

        public IActionResult EditProduct(int id)
        {
            Product menu = db.Get<Product>(id);
            return View(menu);
        }

        [HttpPost]
        public IActionResult Edit(Product menu)
        {

            db.Update(menu);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Product menu = db.Get<Product>(id);
            db.Delete(menu);
            return RedirectToAction("Index");
        }
        //public IActionResult Edit(int id)
    }
}
