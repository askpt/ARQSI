using IDEIBiblio.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace IDEIBiblio.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ApplicationDbContext")
        {
            
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Editor> Editors { get; set; }
    }
}