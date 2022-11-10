using Microsoft.EntityFrameworkCore;
using ShoppingList.Models.Data;
using ShoppingList.Models.Data.Models;

namespace ShoppingList.Services
{
    public class CategoryServices
    {
        private readonly ApplicationDbContext _context;

        public CategoryServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Category>> GetAllCategoriesAsync()
        {
            var categories = await _context
                .Categories
                .Include(x => x.Products)
                .ToListAsync();

            return categories
                .Select(x => new Category
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Products = x.Products,
                }).ToArray();
        }

        public async Task CreateCategoryAsync(Category dto)
        {
            _context.Categories.Add(dto);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return (await _context.Categories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == id))!;
        }

        public async Task EditCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
