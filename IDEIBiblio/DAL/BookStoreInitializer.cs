using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using IDEIBiblio.Models;

namespace IDEIBiblio.DAL
{
    public class BookStoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        // seeding method
        protected override void Seed(ApplicationDbContext context)
        {
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




            // it's necessary to add a new context element to the entityFramework element in Web.config file
        }
    }
}