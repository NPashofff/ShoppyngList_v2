using System.Collections.Immutable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models.Data.Models;
using ShoppingList.Services;

namespace ShoppingList.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryServices _categoryServices;
        
        public CategoryController(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public async Task<ActionResult> Index()
        {
            var categories = await _categoryServices.GetAllCategoriesAsync();
            return View(categories);
        }
        
        public async Task<ActionResult> Details(int id)
        {
            var category = await _categoryServices.GetCategoryByIdAsync(id);
            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category category)
        {
            await _categoryServices.CreateCategoryAsync(category);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            Category category = await _categoryServices.GetCategoryByIdAsync(id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Category category)
        {
            await _categoryServices.EditCategoryAsync(category);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
