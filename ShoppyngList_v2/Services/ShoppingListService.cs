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
                .FirstOrDefaultAsync(x => x.Id == id /*&& x.IsDeleted == false*/);

            //return new ProductCategoryDto()
            //{
            //    Id = productCategory.Id,
            //    Name = productCategory.Name,
            //    Description = productCategory.Description,
            //    CreatorUserName = productCategory.CreatorUserName,
            //    IsDeleted = productCategory.IsDeleted,
            //    Products = productCategory.Products
            //};
            return shopList ?? new ShopList();
        }

        public async Task CreateProduct(Product product, int productCategoryId)
        {
            //var productCategory = await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == productCategoryId);
            //productCategory.Products.Add(product);
            //var x = await _context.SaveChangesAsync();
        }

        public async Task BuyProduct(int id)
        {
            ////var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            ////product.IsBuy = true;
            ////await _context.SaveChangesAsync();
        }

        public async Task DeleteProductCategory(int id)
        {
            //var productCategory = await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == id);
            //productCategory.IsDeleted = true;
            //await _context.SaveChangesAsync();
        }

        //public async Task UpdateProductCategoryAsync(ProductCategoryDto productCategoryDto)
        //{
        //    //var productCategory =await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == productCategoryDto.Id);
        //    //productCategory.Name = productCategoryDto.Name;
        //    //productCategory.Description = productCategoryDto.Description;
        //    // _context.ProductCategories.Update(productCategory);

        //    // await _context.SaveChangesAsync();
        //}
        public async Task UpdateShopListAsync(ShopList shopList)
        {
            var shopListForUpdate = await _context.ShopLists.FirstOrDefaultAsync(x => x.Id == shopList.Id);
            shopListForUpdate.Name = shopList.Name;
            await _context.SaveChangesAsync();
        }
    }
}
