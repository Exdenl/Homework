using System;
using System.Collections.Generic;

namespace OrderManagement
{
    //订单类
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderDetails> Details { get; set; } = new List<OrderDetails>();
        public double TotalAmount => Details.Sum(d => d.TotalPrice);

        public Order(int orderId, Customer customer)
        {
            OrderId = orderId;
            Customer = customer;
        }

        public void AddDetail(OrderDetails detail)
        {
            if (!Details.Contains(detail))
                Details.Add(detail);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is Order other)
            {
                return OrderId == other.OrderId;
            }
            return false;
        }

        public override int GetHashCode() => OrderId.GetHashCode();

        public override string ToString() =>
            $"订单 #{OrderId}\n客户: {Customer}\n明细:\n" +
            $"{string.Join("\n", Details.Select(d => "  " + d))}\n总金额: ${TotalAmount}";
    }
}