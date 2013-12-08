using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDEIBiblio.Models;
using IDEIBiblio.DAL;

namespace IDEIBiblio.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        //
        // GET: /Checkout/
        public ActionResult ShowsAddressAndPayment()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ShowsAddressAndPayment()
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                order.Username = User.Identity.Name;
                order.OrderDate = DateTime.Now;

                // saving the order
                context.Orders.Add(order);
                context.SaveChanges();

                // processing the order
                var cart = ShoppingCart.GetCart(this.HttpContext);
                cart.CreateOrder(order);
                return RedirectToAction("Order completed", new { id = order.OrderId });
            }
            catch
            {
                return View(order);
            }
        }


        public ActionResult OrderCompleted(int id)
        {
            bool orderIsValid = context.Orders.Any(o => o.OrderId == id && o.Username == User.Identity.Name);

            if(orderIsValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
     
	}
}