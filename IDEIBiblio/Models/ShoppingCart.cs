// Shopping Cart business logic

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDEIBiblio.DAL;


namespace IDEIBiblio.Models
{
    public partial class ShoppingCart
    {
        ApplicationDbContext context = new ApplicationDbContext();

        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";

        
        /* GetCart
         * static method that allow controllers to get a cart object
         */
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }


        /* GetCart 
         * (helper method)
         */
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }


        /* AddToCart
         * takes a book and adds it to user's cart
         * (creates a new row if it's a new book or increments quantity if it already exists)
         */
        public void AddToCart(Book book)
        {
            var cartItem = context.Carts.SingleOrDefault(c => c.CartId == ShoppingCartId && c.BookId == book.BookID);

            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    BookId = book.BookID,
                    CartId = ShoppingCartId,
                    NumberOfItems = 1,
                    DateCreated = DateTime.Now
                };
                context.Carts.Add(cartItem);
            }
            else
            {
                cartItem.NumberOfItems++;
            }
            context.SaveChanges();
        }


        /* RemoveFromCart
         * takes a bookID and removes it from the cart 
         * (if there was a single book the row is removed)
         */
        public int RemoveFromCart(int id)
        {
            var cartItem = context.Carts.Single(cart => cart.CartId == ShoppingCartId && cart.RecordId == id);
            int itemCount = 0;

            if(cartItem != null)
            {
                if(cartItem.NumberOfItems > 1)
                {
                    cartItem.NumberOfItems--;
                    itemCount = cartItem.NumberOfItems;
                }
                else
                {
                    context.Carts.Remove(cartItem);
                }
                context.SaveChanges();
            }

            return itemCount;
        }


        /* GetCartId
         * (HttpContextBase allows access to cookies)
         */
        public string GetCartId(HttpContextBase context)
        {
            if(context.Session[CartSessionKey] == null)
            {
                if(!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    Guid tempCardId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCardId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }


        /* RemoveAllItems
         * removes all items from the shopping cart
         */
        public void RemoveAllItems()
        {
            var cartItems = context.Carts.Where(cart => cart.CartId == ShoppingCartId);
            foreach(var cartItem in cartItems)
            {
                context.Carts.Remove(cartItem);
            }
            context.SaveChanges();
        }


        /* GetCartItems
         * returns a list of all shopping cart items
         */
        public List<Cart> GetCartItems()
        {
            return context.Carts.Where(cart => cart.CartId == ShoppingCartId).ToList();
        }


        /* GetTotalNumberOfItems
         * returns the total number of items in the shopping cart
         */
        public int GetTotalNumberOfItems()
        {
            // summing up the count of each individual item
            int? count = (from cartItems in context.Carts where cartItems.CartId == ShoppingCartId select (int?)cartItems.NumberOfItems).Sum();
            // returning 0 if it's null
            return count ?? 0;
        }


        /* GetTotalPrice
         * returns the calculated total cost of all items in the cart
         */
        public decimal GetTotalPrice()
        {
            decimal total;
            // summing up each item price multiplied by unitary price
            try
            {
                total = (decimal)(from cartItems in context.Carts where cartItems.CartId == ShoppingCartId select (int?)cartItems.NumberOfItems * cartItems.Book.Price).Sum();

            }
            catch (Exception)
            {

                return decimal.Zero;
            }
            return total;
            //return 0;
        }


        /* CreateOrder
         * converts the shopping cart to an order, for checkout
         */
        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;
            var cartItems = GetCartItems();

            // going through all items in the cart and adding order details for each of them
            foreach(var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    BookId = item.BookId,
                    OrderId = order.OrderId,
                    UnitaryPrice = (decimal)item.Book.Price,
                    NumberOfItems = item.NumberOfItems,
        
                };
                
                // updating total cost
                orderTotal += (item.NumberOfItems * (decimal)item.Book.Price);

                context.OrderDetails.Add(orderDetail);
            }

            order.Total = orderTotal;
            context.Orders.Add(order);
            //context.SaveChanges();
            RemoveAllItems();
            return order.OrderId;
        }


        /* MoveCartWhenUserLogsIn
         * when a user logs in, all the cart in associated with the user
         */
        public void MoveCartWhenUserLogsIn(string username)
        {
            var shoppingCart = context.Carts.Where(c => c.CartId == ShoppingCartId);

            foreach(Cart item in shoppingCart)
            {
                item.CartId = username;
            }

            context.SaveChanges();
        }
    }
}