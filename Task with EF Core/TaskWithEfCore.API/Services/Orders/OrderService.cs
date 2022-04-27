using System.Linq;
using System.Threading.Tasks;
using TaskWithEFCore.Infrastructure.Brokers;
using TaskWithEFCore.Infrastructure.Models;

namespace TaskWithEfCore.API.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IStorageBroker storageBroker;

        public OrderService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public async ValueTask<Order> AddProductAsync(Order order) =>
            await this.storageBroker.InsertOrderAsync(order);

        public async ValueTask<Order> RetrieveOrderByIdAsync(int orderId) =>
            await this.storageBroker.SelectOrderByIdAsync(orderId);

        public IQueryable<Order> RetrieveAllOrders(Order order) =>
            this.storageBroker.SelectAllOrders(order);

        public async ValueTask<Order> ModifyOrderAsync(Order order) =>
            await this.storageBroker.UpdateOrderAsync(order);

        public async ValueTask<Order> RemoveOrderAsync(int orderId)
        {
            Order order = await this.storageBroker.SelectOrderByIdAsync(orderId);

            return await this.storageBroker.DeleteOrderAsync(order);
        }        
    }
}
