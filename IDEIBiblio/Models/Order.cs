using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IDEIBiblio.Models
{
    public class Order
    {
       [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [ScaffoldColumn(false)]
        public string Username { get; set; }

        [Required(ErrorMessage = "First name is mandatory")]
        [StringLength(200)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is mandatory")]
        [StringLength(200)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is mandatory")]
        [StringLength(200)]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is mandatory")]
        [StringLength(200)]
        public string City { get; set; }

        [Required(ErrorMessage = "Postal code is mandatory")]
        [StringLength(10)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country is mandatory")]
        [StringLength(20)]
        public string Country { get; set; }

        [RegularExpression(@"A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}", ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}