using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement
{
    //订单服务类
    public class OrderService
    {
        private List<Order> orders = new List<Order>();

        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
                throw new ArgumentException($"订单 #{order.OrderId} 已存在！");
            orders.Add(order);
        }

        public void RemoveOrder(int orderId)
        {
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
                throw new ArgumentException($"订单 #{orderId} 未找到！");
            orders.Remove(order);
        }

        public void UpdateOrder(int orderId, Order updatedOrder)
        {
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
                throw new ArgumentException($"订单 #{orderId} 未找到！");
            order.Customer = updatedOrder.Customer;
            order.Details.Clear();
            updatedOrder.Details.ForEach(d => order.AddDetail(d));
        }

        //不同方式实现查询功能
        public List<Order> QueryByOrderId(int orderId) =>
            orders.Where(o => o.OrderId == orderId)
                  .OrderBy(o => o.TotalAmount)
                  .ToList();

        public List<Order> QueryByProductName(string productName) =>
            orders.Where(o => o.Details.Any(d => d.Product.Name.Contains(productName)))
                  .OrderBy(o => o.TotalAmount)
                  .ToList();

        public List<Order> QueryByCustomer(string customerName) =>
            orders.Where(o => o.Customer.Name.Contains(customerName))
                  .OrderBy(o => o.TotalAmount)
                  .ToList();

        public List<Order> QueryByAmount(double minAmount, double maxAmount) =>
            orders.Where(o => o.TotalAmount >= minAmount && o.TotalAmount <= maxAmount)
                  .OrderBy(o => o.TotalAmount)
                  .ToList();

        public void SortOrders(Func<Order, object>? keySelector = null)
        {
            if (keySelector == null)
            {
                orders.Sort((a, b) => a.OrderId.CompareTo(b.OrderId));
            }
            else
            {
                orders.Sort((a, b) => Comparer<object>.Create((x, y) =>
                    (x?.ToString() ?? "").CompareTo(y?.ToString() ?? ""))
                    .Compare(keySelector(a), keySelector(b)));
            }
        }

        public List<Order> GetAllOrders() => orders;
    }
}