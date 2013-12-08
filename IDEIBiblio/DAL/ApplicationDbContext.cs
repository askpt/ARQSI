using IDEIBiblio.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using IDEIBiblio.ViewModels;

namespace IDEIBiblio.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Editor> Editors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Periodicity> Periodicities { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<ShoppingCartViewModel> ShoppingCartViewModels { get; set; }
    }
}