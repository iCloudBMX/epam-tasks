using System.ComponentModel.DataAnnotations.Schema;

namespace MvcPrinciples.Model.Models
{
    [Table("Products")]
    public class Product
    {
        [Column("ProductID")]
        public int Id { get; set; }

        [Column("ProductName")]
        public string Name { get; set; }
        
        [Column("QuantityPerUnit")]
        public string QuantityPerUnit { get; set; }

        [Column("UnitPrice")]
        public decimal Price { get; set; }

        [Column("UnitsInStock")]
        public short UnitsInStock { get; set; }

        [Column("UnitsOnOrder")]
        public short UnitsOnOrder { get; set; }

        [Column("ReorderLevel")]
        public short ReorderLevel { get; set; }

        [Column("Discontinued")]
        public bool Discontinued { get; set; }

        [Column("CategoryID")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Column("SupplierID")]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
