using Microsoft.AspNetCore.Identity;

namespace CMS_Shopping_Cart.Models
{
    public class AppUser : IdentityUser
    {
        public string Occupation { get; set; }
    }
}
