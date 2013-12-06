using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDEIBiblio.Models
{
    public class Periodicity
    {
        public int PeriodicityID { get; set; }
        public string Name { get; set; }
        public int NumberofDays { get; set; }
    }
}