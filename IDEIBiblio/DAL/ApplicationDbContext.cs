using IDEIBiblio.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace IDEIBiblio.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            
        }
        public DbSet<Author> Authors { get; set; }
    }
}