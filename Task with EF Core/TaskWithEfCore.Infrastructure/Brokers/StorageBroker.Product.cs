﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading.Tasks;
using TaskWithEFCore.Infrastructure.Models;

namespace TaskWithEFCore.Infrastructure.Brokers
{
    public partial class StorageBroker
    {
        public DbSet<Product> Products { get; set; }
        
        public async ValueTask<Product> InsertProductAsync(Product product)
        {
            using var broker =
                new StorageBroker(this.configuration);

            EntityEntry<Product> productEntityEntry =
                await broker.Products.AddAsync(product);

            await broker.SaveChangesAsync();

            return productEntityEntry.Entity;
        }

        public IQueryable<Product> SelectAllProducts()
        {
            using var broker =
                new StorageBroker(this.configuration);

            return broker.Products;
        }

        public async ValueTask<Product> SelectProductByIdAsync(int id)
        {
            using var broker =
                new StorageBroker(this.configuration);

            return await broker.Products.FindAsync(id);
        }

        public async ValueTask<Product> UpdateProductAsync(Product product)
        {
            using var broker =
                new StorageBroker(this.configuration);

            EntityEntry<Product> productEntityEntry =
                broker.Products.Update(product);

            await broker.SaveChangesAsync();

            return productEntityEntry.Entity;
        }

        public async ValueTask<Product> DeleteProductAsync(Product product)
        {
            using var broker =
                new StorageBroker(this.configuration);

            EntityEntry<Product> productEntityEntry =
                broker.Products.Remove(product);

            await broker.SaveChangesAsync();

            return productEntityEntry.Entity;
        }
    }
}
