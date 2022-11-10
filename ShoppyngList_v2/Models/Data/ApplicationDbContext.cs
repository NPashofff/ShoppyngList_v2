using Microsoft.EntityFrameworkCore;
using ShoppingList.Models.Data.Models;

namespace ShoppingList.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ShopList> ShopLists { get; set; }

        public DbSet<ListProduct> ListProducts { get; set; }
        
        
    }
}