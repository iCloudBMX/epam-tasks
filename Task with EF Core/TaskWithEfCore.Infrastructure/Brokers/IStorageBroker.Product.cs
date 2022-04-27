using System.Linq;
using System.Threading.Tasks;
using TaskWithEFCore.Infrastructure.Models;

namespace TaskWithEFCore.Infrastructure.Brokers
{
    public partial interface IStorageBroker
    {
        ValueTask<Product> InsertProductAsync(Product product);
        IQueryable<Product> SelectAllProducts();
        ValueTask<Product> SelectProductByIdAsync(int productId);
        ValueTask<Product> UpdateProductAsync(Product product);
        ValueTask<Product> DeleteProductAsync(Product product);        
    }
}
