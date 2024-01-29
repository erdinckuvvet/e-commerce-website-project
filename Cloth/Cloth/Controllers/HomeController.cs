using Cloth.Models;
using Cloth.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cloth.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult Search(Gender? gender, Category? category, string keyword)
        {
            var products = db.Products.ToList();

            if (category.HasValue)
            {
                products = products.Where(p => p.Category == category.Value).ToList();
            }

            if (gender.HasValue)
            {
                products = products.Where(p => p.Gender == gender.Value).ToList();
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                products = products.Where(p => p.Name.Contains(keyword)).ToList();
            }

            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}