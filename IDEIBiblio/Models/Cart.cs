﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IDEIBiblio.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int IProductId { get; set; }
        public int NumberOfItems { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual IProduct IProduct { get; set; }
    }
}