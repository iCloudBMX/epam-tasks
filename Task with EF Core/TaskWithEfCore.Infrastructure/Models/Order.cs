using System;

namespace TaskWithEFCore.Infrastructure.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Statuses Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
