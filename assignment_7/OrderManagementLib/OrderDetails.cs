using System;

namespace OrderManagement
{
    //订单明细类
    public class OrderDetails
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice => Product.Price * Quantity;

        public OrderDetails(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is OrderDetails other)
            {
                return Product.Name == other.Product.Name;
            }
            return false;
        }

        public override int GetHashCode() => Product.Name.GetHashCode();

        public override string ToString() => $"{Product} × {Quantity} = ${TotalPrice}";
    }
}