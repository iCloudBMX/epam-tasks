using MvcPrinciples.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPrinciples.Services.Interfaces
{
    public interface IProductService
    {
        IQueryable<Product> RetrieveAllProducts();
        ValueTask<Product> RetrieveProductByIdAsync(int productId);
        ValueTask<Product> ModifyProductAsync(Product product, int productId);
        ValueTask<Product> RemoveProductAsync(int productId);
    }
}
