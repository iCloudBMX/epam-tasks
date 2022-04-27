using Microsoft.EntityFrameworkCore;
using TaskWithEFCore.Infrastructure.Models;

namespace TaskWithEFCore.Infrastructure.Brokers
{
    public partial class StorageBroker
    {
        private static void AddOrderReferences(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(order => order.Product)
                .WithMany(product => product.Orders)
                .HasForeignKey(order => order.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
