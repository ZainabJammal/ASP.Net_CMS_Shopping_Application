using CMS_Shopping_Cart.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS_Shopping_Cart.Infrastructure
{
    public class CmsShoppingCartContext : DbContext
    {
        public CmsShoppingCartContext(DbContextOptions<CmsShoppingCartContext> options):base(options)
        {
        }

        public DbSet<Page> Pages { get; set; }
    }
}
