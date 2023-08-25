using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CMS_Shopping_Cart.Models
{
    [Keyless]
    public class User
    {
        [Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Minimum length is 4")]
        public string Password { get; set; }

    }
}
