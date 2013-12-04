using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public enum Category
    {
        Romance,
        Terror
    }

    public class Book
    {
        public IList<Author> Authors { get; set; }
        public Category Category { get; set; }
        public Editor Editor { get; set; }
        public float Price { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
    }
}