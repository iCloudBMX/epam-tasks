using System.Linq;
using System.Threading.Tasks;
using TaskWithEFCore.Infrastructure.Models;

namespace TaskWithEFCore.Infrastructure.Brokers
{
    public partial interface IStorageBroker
    {
        ValueTask<Order> InsertOrderAsync(Order order);
        IQueryable<Order> SelectAllOrders(Order order);
        ValueTask<Order> SelectOrderByIdAsync(int orderId);
        ValueTask<Order> UpdateOrderAsync(Order order);
        ValueTask<Order> DeleteOrderAsync(Order order);        
    }
}
