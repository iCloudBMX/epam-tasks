using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration configuration;

        public HomeController(
            ILogger<HomeController> logger, 
            IProductService productService, 
            ICategoryService categoryService,
            IConfiguration configuration)
        {
            _logger = logger;
            this.productService = productService;
            this.categoryService = categoryService;
            this.configuration = configuration;
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
            int maxNumberOfProducts = this.configuration.GetValue<int>("MaxProducts");

            var productViewModel = new ProductViewModel
            {
                Products = maxNumberOfProducts > 0 ?
                    this.productService.RetrieveAllProducts().Take(maxNumberOfProducts).ToList()
                    : this.productService.RetrieveAllProducts().ToList()
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
