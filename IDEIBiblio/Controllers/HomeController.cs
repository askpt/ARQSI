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
           
            // trying to build a suggestion list
            var orderDetailsList = db.OrderDetails.ToList();
            var orderedList = (from o in orderDetailsList
                               group o by new { o.BookId } into oo
                               select new
                               {
                                   oo.Key.BookId,
                                   score = oo.Sum(s => s.NumberOfItems)
                               }).OrderByDescending(i => i.score);

            // if it's not possible (e.g, user that never shopped before)
            if(orderedList != null)
            {
                // below needs fix
                // ViewData["Books"] = orderedList.ToList();
               
                // line below is temporary until above is fixed
                List<Book> finalBookList = new List<Book>();
                foreach (var item in orderedList)
                {
                    finalBookList.Add(db.Books.Find(item.BookId));
                }
                ViewData["Books"] = finalBookList;
            }
            else
            {
                ViewData["Books"] = books.ToList();
            }
           
            // magazines still need suggestion list
            var magazines = db.Magazines.Include(m => m.Author).Include(m => m.Category).Include(m => m.Editor).Include(m => m.Periodicy);
            ViewData["Magazines"] = magazines.ToList();

            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Academic project in the scope of Systems Architecture (ARQSI)";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Authors";

            return View();
        }
    }
}