using Microsoft.AspNetCore.Identity;

namespace Common.Models
{
    public class AppUser : IdentityUser
    {
        public string Occupation { get; set; }
    }
}
