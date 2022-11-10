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

        public async Task Create(Category category)
        {
           // _context.ProductCategories.Add(category);
            await _context.SaveChangesAsync();
        }

        //public async Task<ICollection<ProductCategoryDto>> GetAllProductCategoryByUser(string userName)
        //{
        //   // var productCategories = await _context.ProductCategories
        //      //  .Where(x => x.CreatorUserName == userName && x.IsDeleted == false)
        //       // .ToListAsync();

        //    //return productCategories.Select(pc => new ProductCategoryDto
        //    //    {
        //    //        Id = pc.Id,
        //    //        Name = pc.Name,
        //    //        Description = pc.Description,
        //    //        CreatorUserName = pc.CreatorUserName,
        //    //        Products = pc.Products
        //    //    })
        //    //    .ToList();
        //    return null;
        //}

        //public async Task<ProductCategoryDto> GetProductCategoryByIdAsync(int id)
        //{
        //    //var productCategory = await _context
        //    //    .ProductCategories
        //    //    .Include(x => x.Products)
        //    //    .FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

        //    //return new ProductCategoryDto()
        //    //{
        //    //    Id = productCategory.Id,
        //    //    Name = productCategory.Name,
        //    //    Description = productCategory.Description,
        //    //    CreatorUserName = productCategory.CreatorUserName,
        //    //    IsDeleted = productCategory.IsDeleted,
        //    //    Products = productCategory.Products
        //    //};
        //    return new ProductCategoryDto();
        //}

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
    }
}
