namespace IDEIBiblio.Migrations
{
    using IDEIBiblio.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    // membership API
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<IDEIBiblio.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "IDEIBiblio.DAL.ApplicationDbContext";
        }


        // this method adds users and roles when Seed is called
        bool AddUserAndRole(IDEIBiblio.DAL.ApplicationDbContext context, string userName, string pwd, string role)
        {
            IdentityResult identityResult;

            // creating a role
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            identityResult = roleManager.Create(new IdentityRole(role));

            // creating a user
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user1 = new ApplicationUser()
            {
                UserName = userName,
            };
            identityResult = userManager.Create(user1, pwd);

            // associating created user with role
            if (identityResult.Succeeded == false)
            {
                return identityResult.Succeeded;
            }
            identityResult = userManager.AddToRole(user1.Id, role);

            return identityResult.Succeeded;
        }


        protected override void Seed(IDEIBiblio.DAL.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // calling test user(s) and role(s)
            AddUserAndRole(context, "Costumer1", "Passw0rd1", "CostumerRole");
            AddUserAndRole(context, "Admin", "Adm1nistrator", "AdminRole");
            AddUserAndRole(context, "Manager", "ProductMan4ger", "ManagerRole");

            // initializing DB with Editors
            context.Editors.AddOrUpdate(
                    p => p.Name,
                    new Editor { Name = "Fruta Lda", Address = "Estadio das Antas", Email = "antas_a_arder@fruta.com", Phone = 222424671 },
                    new Editor { Name = "Bertrand", Address = "Rua das Flores 41", Email = "info@bertrand.pt", Phone = 21387430 }
            );

            // initializing DB with Authors
            context.Authors.AddOrUpdate(
                p => p.Name,
                new Author { Name = "Pinto da Costa" },
                new Author { Name = "Jorge Jesus" },
                new Author { Name = "Pedro Proença" },
                new Author { Name = "Hugo Miguel" }
            );

            // initializing DB with Categories
            context.Categories.AddOrUpdate(
                c => c.Name,
                 new Category { Name = "Terror" },
                 new Category { Name = "Sports" },
                 new Category { Name = "Romance" }
             );

            // initializing DB with Books
            context.Books.AddOrUpdate(
                b => b.ISBN,
                new Book { Title = "O Meu Apito Dourado", AuthorID = 3, EditorID = 1, Price = 15.99f, CategoryID = 1, ISBN = 1233122134, Year = 2012 },
                new Book { Title = "Páginas Amarelas de Um Árbitro", AuthorID = 1, EditorID = 1, Price = 15.99f, CategoryID = 1, ISBN = 1253122134, Year = 2011 }
                );

            // initializing DB with Periodicals
            context.Periodicities.AddOrUpdate(
                p => p.Name,
                new Periodicity { Name = "Weekly", NumberofDays = 7 },
                new Periodicity { Name = "Montly", NumberofDays = 30 }
                );

            // initializing DB with Magazines
            context.Magazines.AddOrUpdate(
                m => m.Title,
                new Magazine { Title="A Mística", AuthorID=2, CategoryID=2, EditorID=2, Issue="Ano 2013", Number="2", PeriodicityID=2, Price=3.99f, Publish= new DateTime(2013,2,19)},
                new Magazine { Title="Almanaque da Arbitragem", AuthorID=4, CategoryID=3, EditorID=1, Issue="Ano 2012", Number="30", PeriodicityID=1, Price=1.99f, Publish= new DateTime(2012,5,20)}
                );
        }
    }
}
