using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Models;

namespace OnlineBookShop.Data
{
    public class OnlineBookShopContext : DbContext
    {
        public OnlineBookShopContext(DbContextOptions<OnlineBookShopContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
