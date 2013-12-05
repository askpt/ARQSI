using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using IDEIBiblio.Models;

namespace IDEIBiblio.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("ShopContext") { }

        public DbSet<Author> Authors { get; set; }
    }
}