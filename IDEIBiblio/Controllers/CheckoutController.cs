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


	}
}