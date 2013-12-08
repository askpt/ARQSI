/* This controller serves 3 main purposes:
 * 1) adding books to the cart
 * 2) removing books from the cart
 * 3) viewing books in the cart
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDEIBiblio.Models;
using IDEIBiblio.ViewModels;
using IDEIBiblio.DAL;

namespace IDEIBiblio.Controllers
{
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // setting up view model
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotalPrice()
            };

            return View(viewModel);
        }


        public ActionResult AddBookToCart(int id)
        {
            // getting book from DB
            var addedBook = context.Books.Single(book => book.BookID == id);
            // adding book to cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedBook);
            // going back to main page to coninue shopping
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult RemoveBookFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            string bookTitle = context.Carts.Single(item => item.RecordId == id).Book.Title;
            int itemCount = cart.RemoveFromCart(id);

            // output to user
            var output = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(bookTitle) + " was removed from your shopping cart.",
                CartTotal = cart.GetTotalPrice(),
                NumberOfItemsInCart = cart.GetTotalNumberOfItems(),
                NumberOfSelectedItem = itemCount,
                DeleteId = id
            };
            return Json(output);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCartItems();
            return PartialView("Cart Summary");
        }
	}
}