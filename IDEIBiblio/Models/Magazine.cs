using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Magazine : IProduct
    {
        public int MagazineID { get; set; }
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int EditorID { get; set; }
        public virtual Editor Editor { get; set; }
        public float Price { get; set; }
        public string Title { get; set; }
        public DateTime Publish { get; set; }
        public string Issue { get; set; }
        public string Number { get; set; }
        public int PeriodicityID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public virtual Periodicity Periodicy { get; set; }
    }
}