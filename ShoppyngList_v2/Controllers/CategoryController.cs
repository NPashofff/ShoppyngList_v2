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
        // GET: CategoryController
        public CategoryController(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public async Task<ActionResult> Index()
        {
            var categories = await _categoryServices.GetAllCategoriesAsync();
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var category = await _categoryServices.GetCategoryByIdAsync(id);
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
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

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Category category = await _categoryServices.GetCategoryByIdAsync(id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
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

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
