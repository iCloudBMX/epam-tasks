using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Threading.Tasks;
using TaskWithEFCore.Infrastructure.Models;

namespace TaskWithEFCore.Infrastructure.Brokers
{
    public partial class StorageBroker
    {
        public DbSet<Order> Orders { get; set; }
        
        public async ValueTask<Order> InsertOrderAsync(Order order)
        {
            using var broker =
                new StorageBroker(this.configuration);

            EntityEntry<Order> orderEntityEntry =
                await broker.AddAsync(order);

            await broker.SaveChangesAsync();

            return orderEntityEntry.Entity;
        }

        public IQueryable<Order> SelectAllOrders(Order order)
        {
            using var broker =
                new StorageBroker(this.configuration);
            
            IQueryable<Order> orders = null;
            
            if(order is null)
                orders = broker.Orders;

            orders = broker.Orders.FromSqlRaw($"SelectAll_Orders {order.CreatedDate}, {order.Status}, {order.ProductId}");

            return orders;
        }

        public async ValueTask<Order> SelectOrderByIdAsync(int orderId)
        {
            using var broker =
                new StorageBroker(this.configuration);

            return await broker.Orders.FindAsync(orderId);
        }

        public async ValueTask<Order> UpdateOrderAsync(Order order)
        {
            using var broker =
                new StorageBroker(this.configuration);

            EntityEntry<Order> orderEntityEntry =
                broker.Orders.Update(order);

            await broker.SaveChangesAsync();

            return orderEntityEntry.Entity;
        }

        public async ValueTask<Order> DeleteOrderAsync(Order order)
        {
            using var broker =
                new StorageBroker(this.configuration);

            EntityEntry<Order> orderEntityEntry =
                broker.Orders.Remove(order);

            await broker.SaveChangesAsync();

            return orderEntityEntry.Entity;
        }
    }
}
