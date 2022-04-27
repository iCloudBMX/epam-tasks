using System.Linq;
using System.Threading.Tasks;
using TaskWithEFCore.Infrastructure.Brokers;
using TaskWithEFCore.Infrastructure.Models;

namespace TaskWithEfCore.API.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IStorageBroker storageBroker;

        public ProductService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }
        
        public async ValueTask<Product> AddProductAsync(Product product) =>
            await this.storageBroker.InsertProductAsync(product);
        
        public async ValueTask<Product> RetrieveProductByIdAsync(int productId) =>
            await this.storageBroker.SelectProductByIdAsync(productId);

        public IQueryable<Product> RetrieveAllProducts() =>
            this.storageBroker.SelectAllProducts();      

        public async ValueTask<Product> ModifyProductAsync(Product product) =>
            await this.storageBroker.UpdateProductAsync(product);

        public async ValueTask<Product> RemoveProductAsync(int productId)
        {
            Product product =
                await this.storageBroker.SelectProductByIdAsync(productId);

            return await this.storageBroker.DeleteProductAsync(product);
        }        
    }
}
