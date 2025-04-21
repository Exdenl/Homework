using System;

namespace OrderManagement
{
    //商品类
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString() => $"{Name} (${Price})";
    }
}