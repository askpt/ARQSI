using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDEIBiblio.Controllers
{
    public class ManagerController : Controller
    {
        //
        // GET: /Manager/ManageProducts
        [Authorize(Roles = "ManagerRole")]
        public ActionResult ManageProducts()
        {
            return View();
        }
               
    }
}
