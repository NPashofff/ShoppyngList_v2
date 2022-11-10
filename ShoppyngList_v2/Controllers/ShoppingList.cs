using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using ShoppingList.Models.Data;
using ShoppingList.Models.Data.Models;
using ShoppingList.Services;
using ShoppyngList_v2.Services;

namespace ShoppingList.Controllers
{
    [Authorize]
    public class ShoppingList : Controller
    {
        private readonly ShoppingListService _shoppingListService;
        private readonly CategoryServices _categoryServices;
        private  readonly ProductService _productService;

        public ShoppingList(ShoppingListService shoppingListService, CategoryServices categoryServices, ProductService productService)
        {
            _shoppingListService = shoppingListService;
            _categoryServices = categoryServices;
            _productService = productService;
        }
        // GET: ShoppingList
        public async Task<ActionResult> Index()
        {
            return View(await _shoppingListService.GetAllProductCategoryByUser(User.GetNameIdentifierId()!));
        }

        // GET: ShoppingList/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var shopList = await _shoppingListService.GetProductCategoryByIdAsync(id);
            return View(shopList);
        }

        // GET: ShoppingList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ShopList shopList)
        {
            shopList.UserId = User.GetNameIdentifierId()!;
            await _shoppingListService.Create(shopList);

            return RedirectToAction(nameof(Index));
        }


        public async Task<ActionResult> SaveList(bool isBought, string listProduct, string productCategoryId)
        {
            if (!isBought)
            {
                await _shoppingListService.BuyProduct(int.Parse(listProduct));
            }
            return Redirect("/ShoppingList/Details?id=" + productCategoryId);
        }

        // GET: ShoppingList/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var shopList = await _shoppingListService.GetProductCategoryByIdAsync(id);
            return View(shopList);
        }

        // POST: ShoppingList/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ShopList shopList)
        {
            await _shoppingListService.UpdateShopListAsync(shopList);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingList/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            await _shoppingListService.DeleteProductCategory(id);
            return Redirect("/ShoppingList/Index");
        }

        public IActionResult CreateProduct(int productCategoryId)
        {
            ViewBag.productCategoryId = productCategoryId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product product, int productCategoryId)
        {
            await _shoppingListService.CreateProduct(product, productCategoryId);
            return Redirect("/ShoppingList/Details?id=" + productCategoryId);
        }
        
        public async Task<ActionResult> AddCategory(int shopListId)
        {
            ViewBag.shopListId = shopListId;
            return View(await _categoryServices.GetAllCategoriesAsync());
        }
        public async Task<ActionResult> AddCategoryToShpList(int id, int shopListId)
        {
            await _shoppingListService.AddCategoryToShopList(id, shopListId);
            return Redirect("/ShoppingList/Details?id=" + shopListId);
        }

        public async Task<ActionResult> AddProduct(int shopListId, int categoryId)
        {
            ViewBag.shopListId = shopListId;
            return View(await _productService.GetProductByCategoryAsync(categoryId));
        }
        
        public async Task<ActionResult> AddProductToShopingList(int id, int shopListId)
        {
            await _shoppingListService.AddProductToShopListAsync(id, shopListId);
            return Redirect("/ShoppingList/Details?id=" + shopListId);
        }
    }
}
