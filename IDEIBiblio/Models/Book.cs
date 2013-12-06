using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Book : IProduct
    {
        public int BookID { get; set; }
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int EditorID { get; set; }
        public virtual Editor Editor { get; set; }
        [Range(1, 999), DataType(DataType.Currency)]
        public float Price { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int ISBN { get; set; }

    }
}