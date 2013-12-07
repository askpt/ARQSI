using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace IDEIBiblio.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}