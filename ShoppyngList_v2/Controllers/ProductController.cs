using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models.Data.Models;
using ShoppyngList_v2.Services;

namespace ShoppyngList_v2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        

        public ActionResult Create(int categoryId)
        {
            return View(new Product() { CategoryId = categoryId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product)
        {
            await _productService.AddProductAsync(product);
            try
            {
                return Redirect("/Category/Details/" + product.CategoryId);
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            return View(await _productService.GetProductByIdAsinc(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Product product)
        {
            var updatedProduct = await _productService.UpdateProductAsync(product);

            return Redirect("/Category/Details/" + updatedProduct.CategoryId);

        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
