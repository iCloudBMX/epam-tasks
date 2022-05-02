using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        
        public async ValueTask<Product> InsertProductAsync(Product product)
        {
            EntityEntry<Product> entityEntry =
                await this.applicationDbContext.AddAsync(product);

            await this.applicationDbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<Product> UpdateProductAsync(Product product)
        {
            EntityEntry<Product> entityEntry =
                this.applicationDbContext.Update(product);

            await this.applicationDbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async ValueTask<Product> DeleteProductAsync(Product product)
        {
            EntityEntry<Product> entityEntry =
                this.applicationDbContext.Remove(product);

            await this.applicationDbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }
    }
}
