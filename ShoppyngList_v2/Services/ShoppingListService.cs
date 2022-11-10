using Microsoft.EntityFrameworkCore;
using ShoppingList.Models.Data;
using ShoppingList.Models.Data.Models;

namespace ShoppingList.Services
{
    public class ShoppingListService
    {
        private readonly ApplicationDbContext _context;

        public ShoppingListService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ShopList shpoList)
        {
            _context.ShopLists.Add(shpoList);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<ShopList>> GetAllProductCategoryByUser(string userId)
        {
            var userShopLists = await _context.ShopLists
                .Where(x => x.UserId == userId /*&& x.IsDeleted == false*/)
                .ToListAsync();

            return userShopLists;
        }

        public async Task<ShopList> GetProductCategoryByIdAsync(int id)
        {
            var shopList = await _context
                .ShopLists
                .Include(x => x.ListProducts)
                .ThenInclude(s => s.Product)
                .Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.Id == id /*&& x.IsDeleted == false*/);
            
            return shopList ?? new ShopList();
        }
        
        public async Task BuyProduct(int id)
        {
            var product = await _context.ListProducts.FirstOrDefaultAsync(x => x.Id == id);
            product.IsBought = true;
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateShopListAsync(ShopList shopList)
        {
            var shopListForUpdate = await _context.ShopLists.FirstOrDefaultAsync(x => x.Id == shopList.Id);
            shopListForUpdate.Name = shopList.Name;
            await _context.SaveChangesAsync();
        }

        public async Task AddCategoryToShopList(int categoryId, int shopListId)
        {
            var shopList = await _context.ShopLists.FirstOrDefaultAsync(x => x.Id == shopListId);
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryId);
            shopList.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task AddProductToShopListAsync(int productId, int shopListId)
        {
            var shopList = await _context.ShopLists.FirstOrDefaultAsync(x => x.Id == shopListId);
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            var listProduct = new ListProduct
            {
                ShopListId = shopListId,
                ShopList = shopList,
                ProductId = productId,
                Product = product
            };
            shopList.ListProducts.Add(listProduct);
            await _context.SaveChangesAsync();
        }
    }
}
