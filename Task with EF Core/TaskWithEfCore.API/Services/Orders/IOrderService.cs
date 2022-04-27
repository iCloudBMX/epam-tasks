using System.Linq;
using System.Threading.Tasks;
using TaskWithEFCore.Infrastructure.Models;

namespace TaskWithEfCore.API.Services.Orders
{
    public interface IOrderService
    {
        ValueTask<Order> AddProductAsync(Order order);
        ValueTask<Order> RetrieveOrderByIdAsync(int orderId);
        IQueryable<Order> RetrieveAllOrders(Order order);
        ValueTask<Order> ModifyOrderAsync(Order order);
        ValueTask<Order> RemoveOrderAsync(int orderId);
    }
}
