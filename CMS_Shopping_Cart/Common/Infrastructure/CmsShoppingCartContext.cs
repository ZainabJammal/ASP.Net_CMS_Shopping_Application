using Common.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Common.Infrastructure
{
    public class CmsShoppingCartContext : IdentityDbContext<AppUser>
    {
        public CmsShoppingCartContext(DbContextOptions<CmsShoppingCartContext> options) : base(options)
        {
        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Common.Models.Login>? Login { get; set; }
        public DbSet<Common.Models.User>? User { get; set; }


    }
}
