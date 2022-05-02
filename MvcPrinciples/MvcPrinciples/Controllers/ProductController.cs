using Microsoft.AspNetCore.Mvc;
using MvcPrinciples.Model.Models;
using MvcPrinciples.Models;
using MvcPrinciples.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MvcPrinciples.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        
        public async ValueTask<IActionResult> Update(int id)
        {
            var product = await this.productService.RetrieveProductByIdAsync(id);

            var productViewModel = new EditProductViewModel
            {
                Name = product.Name,
                Price = product.Price,
                QuantityPerUnit = product.QuantityPerUnit,
            };

            return View(productViewModel);
        }

        [HttpPost]
        public async ValueTask<IActionResult> Update(EditProductViewModel productViewModel, int id)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Id = id,
                    Name = productViewModel.Name,
                    Price = productViewModel.Price,
                    QuantityPerUnit = productViewModel.QuantityPerUnit,
                };
                await this.productService.ModifyProductAsync(product, id);
                return RedirectToAction("Products", "Home");
            }
            
            return View(productViewModel);
        }

        public async ValueTask<IActionResult> Delete(int id)
        {
            var product = await this.productService.RemoveProductAsync(id);
            return View(product);
        }
    }
}
