using Cloth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Cloth.Models.ViewModels;
using System.Threading.Tasks;

namespace Cloth.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Checkout
        public ActionResult Index()
        {
            var query = db.Addresses.Include(element => element.ApplicationUser)
                .Where(element => element.ApplicationUser.UserName == User.Identity.Name).ToList();

            return View(query);
        }
        [HttpPost]
        public  ActionResult Payment(string ProductsVM,string AddressVM)
        {
            List<ProductVM> products = JsonConvert.DeserializeObject<List<ProductVM>>(ProductsVM);
            AddressVM address = JsonConvert.DeserializeObject<AddressVM>(AddressVM);

            List<ProductOrder> productOrders = new List<ProductOrder>();

            string currentUserName = User.Identity.Name;
            ApplicationUser user = db.Users.FirstOrDefault(x => x.UserName == currentUserName);
            Address currentAddress = db.Addresses.FirstOrDefault(x => x.Id == address.Id);

            Order order = new Order
            {
                Address = currentAddress,
                ApplicationUser = user,
                Date = DateTime.UtcNow
            };

            products.ForEach( item =>
            {
                Product product =  db.Products.FirstOrDefault(element => element.Id == item.Id);
                ProductOrder pOrder = new ProductOrder
                {
                    Order = order,
                    Product = product,
                    BoughtAmount = item.BoughtAmount,
                    Size = item.Size
                };
                productOrders.Add(pOrder);
            });

            db.Orders.Add(order);
            db.ProductOrders.AddRange(productOrders);

            db.SaveChanges();

            //return RedirectToAction("Index","Home");
            return Json(new { success = true, message = "Data received successfully" });
        }
    }
}