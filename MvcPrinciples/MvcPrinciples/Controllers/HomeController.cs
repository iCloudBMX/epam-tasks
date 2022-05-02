using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcPrinciples.Models;
using MvcPrinciples.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPrinciples.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public HomeController(
            ILogger<HomeController> logger, 
            IProductService productService, 
            ICategoryService categoryService)
        {
            _logger = logger;
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categories()
        {
            var categoryViewModel = new CategoryViewModel
            {
                Categories = this.categoryService.RetrieveAllCategories().ToList()
            };
            
            return View(categoryViewModel);
        }

        public IActionResult Products()
        {
            var productViewModel = new ProductViewModel
            {
                Products = this.productService.RetrieveAllProducts().ToList()
            };

            return View(productViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
