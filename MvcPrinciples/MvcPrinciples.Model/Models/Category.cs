using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPrinciples.Model.Models
{
    [Table("Categories")]
    public class Category
    {
        [Column("CategoryID")]
        public int Id { get; set; }

        [Column("CategoryName")]
        public string Name { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
