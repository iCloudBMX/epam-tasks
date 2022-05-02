using MvcPrinciples.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPrinciples.Infrastucture.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> SelectAllProducts();
        ValueTask<Product> SelectProductByIdAsync(int productId);
        ValueTask<Product> InsertProductAsync(Product product);
        ValueTask<Product> UpdateProductAsync(Product product);
        ValueTask<Product> DeleteProductAsync(Product product);
    }
}
