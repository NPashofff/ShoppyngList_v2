using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using ShoppingList.Models.Data;
using ShoppingList.Models.Data.Models;
using ShoppingList.Services;

namespace ShoppingList.Controllers
{
    [Authorize]
    public class ShoppingList : Controller
    {
        private readonly ShoppingListService _shoppingListService;

        public ShoppingList(ShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }
        // GET: ShoppingList
        public async Task<ActionResult> Index()
        {
            return View(/*await _shoppingListService.GetAllProductCategoryByUser(User.GetNameIdentifierId()!)*/);
        }

        // GET: ShoppingList/Details/5
        //public async Task<ActionResult> Details(int id)
        //{
        //    var productCategory = await _shoppingListService.GetProductCategoryByIdAsync(id);
        //    return View(productCategory);
        //}

        // GET: ShoppingList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category category)
        {
            //category.CreatorUserName = User.GetNameIdentifierId()!;
            await _shoppingListService.Create(category);

            return RedirectToAction(nameof(Index));
        }


        public async Task<ActionResult> SaveList(bool iss, string productId, string productCategoryId)
        {
            if (!iss)
            {
                await _shoppingListService.BuyProduct(int.Parse(productId));
            }
            return Redirect("/ShoppingList/Details?id=" + productCategoryId);
        }

        // GET: ShoppingList/Edit/5
        //public async Task<ActionResult> Edit(int id)
        //{
        //    var productCategory = await _shoppingListService.GetProductCategoryByIdAsync(id);
        //    return View(productCategory);
        //}

        // POST: ShoppingList/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(ProductCategoryDto productCategoryDto)
        //{
        //    await _shoppingListService.UpdateProductCategoryAsync(productCategoryDto);
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

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
    }
}
