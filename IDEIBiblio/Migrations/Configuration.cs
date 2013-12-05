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
            var editors = new List<Editor>
            {
                new Editor{Name="Fruta Lda", Address="Estadio das Antas", Email="antas_a_arder@fruta.com", Phone=222424671},
                new Editor{Name="Bertrand", Address="Rua das Flores, 41", Email="info@bertrand.pt", Phone=21387430}
            };
            editors.ForEach(s => context.Editors.Add(s));
            context.SaveChanges();

            // initializing DB with authors
            var authors = new List<Author>
            {
                new Author{Name="Pinto da Costa"},
                new Author{Name="Jorge Jesus"},
                new Author{Name="Pedro Proença"},
                new Author{Name="Hugo Miguel"}
            };
            authors.ForEach(s => context.Authors.Add(s));
            context.SaveChanges();
        }
    }
}
