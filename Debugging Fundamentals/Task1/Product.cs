using System;

namespace Task1
{
    public class Product
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public override bool Equals(object comparedObject)
        {
            Product product = comparedObject as Product;

            if (product is null)
                return false;

            if (product.Name == this.Name && product.Price == this.Price)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Price);
        }
    }
}
