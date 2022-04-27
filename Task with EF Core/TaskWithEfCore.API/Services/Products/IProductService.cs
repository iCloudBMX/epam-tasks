using System.Linq;
using System.Threading.Tasks;
using TaskWithEFCore.Infrastructure.Models;

namespace TaskWithEfCore.API.Services.Products
{
    public interface IProductService
    {
        ValueTask<Product> AddProductAsync(Product product);
        ValueTask<Product> RetrieveProductByIdAsync(int productId);
        IQueryable<Product> RetrieveAllProducts();
        ValueTask<Product> ModifyProductAsync(Product product);
        ValueTask<Product> RemoveProductAsync(int productId);
    }
}
