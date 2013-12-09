using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDEIBiblio.Models;
using IDEIBiblio.DAL;
using IDEIBiblio.EmailNotifications;

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
        public ActionResult ShowsAddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                order.Username = User.Identity.Name;
                order.OrderDate = DateTime.Now;

                // saving the order
                //context.Orders.Add(order);
                //context.SaveChanges();

                // processing the order
                var cart = ShoppingCart.GetCart(this.HttpContext);
                cart.CreateOrder(order);

                // sending emaik
                EmailNotifications.EmailNotifications.SendEmailBecauseOrder(order.Email, order.OrderId, (float)order.Total, new List<Book>(), new List<Magazine>());

                return RedirectToAction("OrderCompleted", new { id = order.OrderId });
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