using System;
using System.Collections.Generic;
using System.Linq;


namespace OrderApp
{
    public class OrderItem
    {
        public string Product { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public float Total => Amount * Price;

        public override bool Equals(object obj) => obj is OrderItem item && Product == item.Product;
        public override int GetHashCode() => Product.GetHashCode();
        public override string ToString() => $"{Product} ×{Amount} ¥{Price} (小计:¥{Total})";
    }

    public class Order
    {
        public int ID { get; set; }
        public string Customer { get; set; }
        public List<OrderItem> Items { get; } = new List<OrderItem>();
        public float Total => Items.Sum(i => i.Total);

        public override bool Equals(object obj) => obj is Order order && ID == order.ID;
        public override int GetHashCode() => ID.GetHashCode();
        public override string ToString() =>
            $"订单号:{ID} 客户:{Customer} 总金额:¥{Total}\n明细:\n{string.Join("\n", Items)}\n";
    }

    public class OrderManager
    {
        private List<Order> data = new List<Order>();

        public void Add(Order newOrder)
        {
            if (data.Any(o => o.ID == newOrder.ID))
                throw new Exception("订单号重复！");
            data.Add(newOrder);
        }

        public void Delete(int id)
        {
            var order = data.FirstOrDefault(o => o.ID == id);
            if (order == null) throw new Exception("找不到订单");
            data.Remove(order);
        }

        public void Update(Order newOrder)
        {
            var index = data.FindIndex(o => o.ID == newOrder.ID);
            if (index == -1) throw new Exception("订单不存在");
            data[index] = newOrder;
        }

        public List<Order> Find(Func<Order, bool> condition)
            => data.Where(condition).OrderBy(o => o.Total).ToList();

        public void Sort(Func<Order, Order, int> compare = null)
        {
            data.Sort(compare == null ? (a, b) => a.ID.CompareTo(b.ID) :
                new Comparison<Order>(compare));
        }
    }

    class Program
    {
        static OrderManager manager = new OrderManager();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n1.添加 2.删除 3.修改 4.查询 5.退出");
                Console.Write("请选择:");
                switch (Console.ReadLine())
                {
                    case "1": Add(); break;
                    case "2": Remove(); break;
                    case "3": Modify(); break;
                    case "4": Search(); break;
                    case "5": return;
                }
            }
        }

        static void Add()
        {
            try
            {
                var o = new Order();
                Console.Write("输入订单号:");
                o.ID = int.Parse(Console.ReadLine());
                Console.Write("客户名称:");
                o.Customer = Console.ReadLine();

                Console.WriteLine("输入商品明细（格式：商品名 数量 单价），空行结束");
                while (true)
                {
                    Console.Write("> ");
                    var input = Console.ReadLine().Trim();
                    if (string.IsNullOrEmpty(input)) break;

                    var parts = input.Split();
                    var item = new OrderItem
                    {
                        Product = parts[0],
                        Amount = int.Parse(parts[1]),
                        Price = float.Parse(parts[2])
                    };

                    if (o.Items.Contains(item)) Console.WriteLine("商品重复！");
                    else o.Items.Add(item);
                }
                manager.Add(o);
                Console.WriteLine("添加成功！");
            }
            catch (Exception e) { Console.WriteLine($"出错：{e.Message}"); }
        }

        static void Remove()
        {
            try
            {
                Console.Write("输入要删除的订单号:");
                manager.Delete(int.Parse(Console.ReadLine()));
                Console.WriteLine("删除成功！");
            }
            catch (Exception e) { Console.WriteLine($"出错：{e.Message}"); }
        }

        static void Modify()
        {
            try
            {
                Console.Write("输入要修改的订单号:");
                int id = int.Parse(Console.ReadLine());
                var old = manager.Find(o => o.ID == id).FirstOrDefault() ?? throw new Exception("订单不存在");

                var newOrder = new Order { ID = id, Customer = old.Customer };
                old.Items.ForEach(i => newOrder.Items.Add(i));

                Console.Write($"新客户名称[{old.Customer}]：");
                var newCustomer = Console.ReadLine();
                newOrder.Customer = string.IsNullOrEmpty(newCustomer) ? old.Customer : newCustomer;

                Console.WriteLine("修改明细（格式：a/d 商品名 数量 单价）");
                while (true)
                {
                    Console.Write("> ");
                    var cmd = Console.ReadLine().Split();
                    if (cmd.Length == 0) break;

                    if (cmd[0] == "a")
                    {
                        var item = new OrderItem
                        {
                            Product = cmd[1],
                            Amount = int.Parse(cmd[2]),
                            Price = float.Parse(cmd[3])
                        };
                        if (newOrder.Items.Contains(item)) Console.WriteLine("商品已存在！");
                        else newOrder.Items.Add(item);
                    }
                    else if (cmd[0] == "d")
                    {
                        newOrder.Items.RemoveAll(i => i.Product == cmd[1]);
                    }
                    else break;
                }
                manager.Update(newOrder);
                Console.WriteLine("修改成功！");
            }
            catch (Exception e) { Console.WriteLine($"出错：{e.Message}"); }
        }

        static void Search()
        {
            try
            {
                Console.WriteLine("1.所有订单 2.按订单号 3.按商品 4.按客户 5.按金额区间");
                Console.Write("请选择:");
                var choice = Console.ReadLine();
                List<Order> result = null;

                switch (choice)
                {
                    case "1":
                        result = manager.Find(o => true);
                        break;
                    case "2":
                        Console.Write("输入订单号:");
                        var idInput = Console.ReadLine().Trim();
                        if (int.TryParse(idInput, out int id))
                        {
                            result = manager.Find(o => o.ID == id);
                        }
                        else
                        {
                            Console.WriteLine("订单号格式错误，请输入有效的数字。");
                        }
                        break;
                    case "3":
                        Console.Write("输入商品名:");
                        string productName = Console.ReadLine().Trim();
                        result = manager.Find(o => o.Items.Any(i => i.Product == productName));
                        break;
                    case "4":
                        Console.Write("输入客户名:");
                        var name = Console.ReadLine().Trim();
                        result = manager.Find(o => o.Customer == name);
                        //result = manager.Find(o => o.Customer == Console.ReadLine());
                        break;
                    case "5":
                        Console.Write("最低金额:");
                        float min = float.Parse(Console.ReadLine());
                        Console.Write("最高金额:");
                        result = manager.Find(o => o.Total >= min && o.Total <= float.Parse(Console.ReadLine()));
                        break;
                }

                if (result?.Count > 0) result.ForEach(Console.WriteLine);
                else Console.WriteLine("没有找到订单");
            }
            catch (Exception e) { Console.WriteLine($"出错：{e.Message}"); }
        }
    }
}