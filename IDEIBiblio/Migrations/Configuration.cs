namespace IDEIBiblio.Migrations
{
    using IDEIBiblio.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IDEIBiblio.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "IDEIBiblio.DAL.ApplicationDbContext";
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

            // initializing DB with Editors

            context.Editors.AddOrUpdate(
                    p => p.Name,
                    new Editor { Name = "Fruta Lda", Address = "Estadio das Antas", Email = "antas_a_arder@fruta.com", Phone = 222424671 },
                    new Editor { Name = "Bertrand", Address = "Rua das Flores 41", Email = "info@bertrand.pt", Phone = 21387430 }
            );


            context.Authors.AddOrUpdate(
                p => p.Name,
                new Author { Name = "Pinto da Costa" },
                new Author { Name = "Jorge Jesus" },
                new Author { Name = "Pedro Proença" },
                new Author { Name = "Hugo Miguel" }
            );

            context.Categories.AddOrUpdate(
                c => c.Name,
                 new Category { Name = "Terror" },
                 new Category { Name = "Sports" },
                 new Category { Name = "Romance" }
             );

            context.Books.AddOrUpdate(
                b => b.ISBN,
                new Book { Title = "O Meu Apito Dourado", AuthorID = 3, EditorID = 1, Price = 15.99f, CategoryID = 1, ISBN = 1233122134, Year = 2012 },
                new Book { Title = "Páginas Amarelas de Um Árbitro", AuthorID = 1, EditorID = 1, Price = 15.99f, CategoryID = 1, ISBN = 1253122134, Year = 2011 }
                );

            context.Periodicities.AddOrUpdate(
                p => p.Name,
                new Periodicity { Name = "Weekly", NumberofDays = 7 },
                new Periodicity { Name = "Montly", NumberofDays = 30 }
                );
        }
    }
}
