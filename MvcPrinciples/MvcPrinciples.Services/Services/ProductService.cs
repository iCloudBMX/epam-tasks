using MvcPrinciples.Infrastucture.Interfaces;
using MvcPrinciples.Model.Models;
using MvcPrinciples.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPrinciples.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IQueryable<Product> RetrieveAllProducts()
        {
            return this.productRepository.SelectAllProducts();
        }

        public async ValueTask<Product> RetrieveProductByIdAsync(int productId)
        {
            return await this.productRepository.SelectProductByIdAsync(productId);
        }
    }
}
