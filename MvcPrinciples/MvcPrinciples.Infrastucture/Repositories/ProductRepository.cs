using Microsoft.EntityFrameworkCore;
using MvcPrinciples.Infrastucture.Contexts;
using MvcPrinciples.Infrastucture.Interfaces;
using MvcPrinciples.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPrinciples.Infrastucture.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public IQueryable<Product> SelectAllProducts()
        {
            return this.applicationDbContext.Products
                .Include("Category")
                .Include("Supplier");
        }

        public async ValueTask<Product> SelectProductByIdAsync(int productId)
        {
            return await this.applicationDbContext.Products.FindAsync(productId);
        }
        public ValueTask<Product> InsertProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Product> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Product> DeleteProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
