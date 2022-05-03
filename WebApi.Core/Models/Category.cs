using System.Collections.Generic;

namespace WebApi.Core.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; }
    }
}
