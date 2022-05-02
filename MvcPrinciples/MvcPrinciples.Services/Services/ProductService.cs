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

        public async ValueTask<Product> ModifyProductAsync(Product product, int productId)
        {
            var selectedProduct = await this.productRepository.SelectProductByIdAsync(productId);

            if (selectedProduct == null)
            {
                throw new ArgumentException("Product not found");
            }

            selectedProduct.Name = product.Name;
            selectedProduct.Price = product.Price;

            return await this.productRepository.UpdateProductAsync(selectedProduct);
        }

        public async ValueTask<Product> RemoveProductAsync(int productId)
        {
            var selectedProduct = await this.productRepository.SelectProductByIdAsync(productId);

            if (selectedProduct == null)
            {
                throw new ArgumentException("Product not found");
            }            
            
            return await this.productRepository.DeleteProductAsync(selectedProduct);
        }
    }
}
