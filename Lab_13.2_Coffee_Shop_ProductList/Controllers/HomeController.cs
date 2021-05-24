using Lab_13._2_Coffee_Shop_ProductList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;

namespace Lab_13._2_Coffee_Shop_ProductList.Controllers
{
    public class HomeController : Controller
    {
        static MySqlConnection db = new MySqlConnection("Server=localhost;Database=Coffeehouse;Uid=root;Password=abc123");
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Product> menu = db.GetAll<Product>().ToList();
            return View(menu);
        }

        public IActionResult Detail(int id)
        {
            Product menu = db.Get<Product>(id);
            return View(menu);


        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
