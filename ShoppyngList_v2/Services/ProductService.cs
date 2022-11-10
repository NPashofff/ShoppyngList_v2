using Microsoft.EntityFrameworkCore;
using ShoppingList.Models.Data;
using ShoppingList.Models.Data.Models;

namespace ShoppyngList_v2.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var productForUpdate = await _context
                .Products
                .FirstOrDefaultAsync(x => x.Id == product.Id);
            productForUpdate.Name = product.Name;
            await _context.SaveChangesAsync();
            return productForUpdate;
        }

        public async Task<Product> GetProductByIdAsinc(int id)
        {
            return await _context.Products.FirstAsync(x => x.Id == id);
        }
    }
}
