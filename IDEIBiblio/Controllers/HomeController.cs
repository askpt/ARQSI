using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IDEIBiblio.Models;
using IDEIBiblio.DAL;

namespace IDEIBiblio.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Editor);
            books = db.Books.Include(b => b.Category);
            ViewData["Books"] = books.ToList();

            var magazines = db.Magazines.Include(m => m.Author).Include(m => m.Category).Include(m => m.Editor).Include(m => m.Periodicy);
            ViewData["Magazines"] = magazines.ToList();

            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}