using System;
using System.Collections.Generic;
using System.Data;
using MySqlConnector;
using System.Windows.Forms;

namespace WinForm_test
{
    public partial class MainForm : Form
    {
        // 定义订单和订单明细的数据结构
        private class Order
        {
            public int Id { get; set; }
            public string? OrderNumber { get; set; }
            public string? CustomerName { get; set; }
            public double TotalAmount { get; set; }
            public List<OrderItem> Details { get; set; } = new List<OrderItem>();
        }

        private class OrderItem
        {
            public int Id { get; set; }
            public int OrderId { get; set; }
            public string? ItemName { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
            public double Subtotal => Price * Quantity;
        }

        // 数据库连接字符串
        private string connectionString = "Server=localhost;Database=order_management;Uid=root;Pwd=125374;";

        private List<Order> orders = new List<Order>();

        public MainForm()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            LoadOrders();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadOrders()
        {
            orders.Clear();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM orders";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order
                            {
                                Id = reader.GetInt32("id"),
                                OrderNumber = reader.GetString("order_number"),
                                CustomerName = reader.GetString("customer_name"),
                                TotalAmount = reader.GetDouble("total_amount")
                            };
                            orders.Add(order);
                        }
                    }
                }

                // 加载订单明细
                foreach (Order order in orders)
                {
                    string itemQuery = "SELECT * FROM order_details WHERE order_id = @OrderId";
                    using (MySqlCommand itemCommand = new MySqlCommand(itemQuery, connection))
                    {
                        itemCommand.Parameters.AddWithValue("@OrderId", order.Id);
                        using (MySqlDataReader itemReader = itemCommand.ExecuteReader())
                        {
                            while (itemReader.Read())
                            {
                                OrderItem item = new OrderItem
                                {
                                    Id = itemReader.GetInt32("id"),
                                    OrderId = itemReader.GetInt32("order_id"),
                                    ItemName = itemReader.GetString("item_name"),
                                    Price = itemReader.GetDouble("price"),
                                    Quantity = itemReader.GetInt32("quantity")
                                };
                                order.Details.Add(item);
                            }
                        }
                    }
                }
            }

            // 更新DataGridView1
            dataGridView1.Rows.Clear();
            for (int i = 0; i < orders.Count; i++)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = i + 1;
                dataGridView1.Rows[rowIndex].Cells[1].Value = orders[i].OrderNumber;
                dataGridView1.Rows[rowIndex].Cells[2].Value = orders[i].CustomerName;
                dataGridView1.Rows[rowIndex].Cells[3].Value = orders[i].TotalAmount.ToString("F2");
            }

            if (orders.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
                DisplayOrderDetails(orders[0]);
            }
        }

        private void SaveOrder(Order order)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string insertOrderQuery = "INSERT INTO orders (order_number, customer_name, total_amount) VALUES (@OrderNumber, @CustomerName, @TotalAmount); SELECT LAST_INSERT_ID();";
                using (MySqlCommand orderCommand = new MySqlCommand(insertOrderQuery, connection))
                {
                    orderCommand.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);
                    orderCommand.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                    orderCommand.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                    int orderId = Convert.ToInt32(orderCommand.ExecuteScalar());

                    foreach (OrderItem item in order.Details)
                    {
                        string insertItemQuery = "INSERT INTO order_details (order_id, item_name, price, quantity) VALUES (@OrderId, @ItemName, @Price, @Quantity)";
                        using (MySqlCommand itemCommand = new MySqlCommand(insertItemQuery, connection))
                        {
                            itemCommand.Parameters.AddWithValue("@OrderId", orderId);
                            itemCommand.Parameters.AddWithValue("@ItemName", item.ItemName);
                            itemCommand.Parameters.AddWithValue("@Price", item.Price);
                            itemCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
                            itemCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void UpdateOrder(Order order)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string updateOrderQuery = "UPDATE orders SET order_number = @OrderNumber, customer_name = @CustomerName, total_amount = @TotalAmount WHERE id = @Id";
                using (MySqlCommand orderCommand = new MySqlCommand(updateOrderQuery, connection))
                {
                    orderCommand.Parameters.AddWithValue("@Id", order.Id);
                    orderCommand.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);
                    orderCommand.Parameters.AddWithValue("@CustomerName", order.CustomerName);
                    orderCommand.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                    orderCommand.ExecuteNonQuery();
                }

                // 删除原有的订单明细
                string deleteItemsQuery = "DELETE FROM order_details WHERE order_id = @OrderId";
                using (MySqlCommand deleteItemsCommand = new MySqlCommand(deleteItemsQuery, connection))
                {
                    deleteItemsCommand.Parameters.AddWithValue("@OrderId", order.Id);
                    deleteItemsCommand.ExecuteNonQuery();
                }

                // 插入新的订单明细
                foreach (OrderItem item in order.Details)
                {
                    string insertItemQuery = "INSERT INTO order_details (order_id, item_name, price, quantity) VALUES (@OrderId, @ItemName, @Price, @Quantity)";
                    using (MySqlCommand itemCommand = new MySqlCommand(insertItemQuery, connection))
                    {
                        itemCommand.Parameters.AddWithValue("@OrderId", order.Id);
                        itemCommand.Parameters.AddWithValue("@ItemName", item.ItemName);
                        itemCommand.Parameters.AddWithValue("@Price", item.Price);
                        itemCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
                        itemCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        private void DeleteOrder(int orderId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                // 删除订单明细
                string deleteItemsQuery = "DELETE FROM order_details WHERE order_id = @OrderId";
                using (MySqlCommand deleteItemsCommand = new MySqlCommand(deleteItemsQuery, connection))
                {
                    deleteItemsCommand.Parameters.AddWithValue("@OrderId", orderId);
                    deleteItemsCommand.ExecuteNonQuery();
                }

                // 删除订单
                string deleteOrderQuery = "DELETE FROM orders WHERE id = @Id";
                using (MySqlCommand deleteOrderCommand = new MySqlCommand(deleteOrderQuery, connection))
                {
                    deleteOrderCommand.Parameters.AddWithValue("@Id", orderId);
                    deleteOrderCommand.ExecuteNonQuery();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OrderDetailsForm form2 = new OrderDetailsForm())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    Order newOrder = new Order
                    {
                        OrderNumber = form2.OrderNumber,
                        CustomerName = form2.CustomerName,
                        TotalAmount = double.TryParse(form2.TotalAmount, out double t) ? t : 0
                    };

                    foreach (DataGridViewRow row in form2.OrderDetails.Rows)
                    {
                        if (row.Cells[0].Value == null || string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
                            continue;

                        string? itemName = row.Cells[0].Value.ToString();
                        double price = double.TryParse(row.Cells[1].Value.ToString(), out double p) ? p : 0;
                        int quantity = int.TryParse(row.Cells[2].Value.ToString(), out int q) ? q : 0;

                        newOrder.Details.Add(new OrderItem
                        {
                            ItemName = itemName,
                            Price = price,
                            Quantity = quantity
                        });
                    }

                    orders.Add(newOrder);
                    SaveOrder(newOrder);

                    int rowIndex = dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowIndex].Cells[0].Value = rowIndex + 1;
                    dataGridView1.Rows[rowIndex].Cells[1].Value = newOrder.OrderNumber;
                    dataGridView1.Rows[rowIndex].Cells[2].Value = newOrder.CustomerName;
                    dataGridView1.Rows[rowIndex].Cells[3].Value = newOrder.TotalAmount.ToString("F2");

                    if (orders.Count == 1)
                    {
                        dataGridView1.Rows[0].Selected = true;
                        DisplayOrderDetails(orders[0]);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要修改的订单");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            if (selectedRow.Cells[1].Value == null || string.IsNullOrWhiteSpace(selectedRow.Cells[1].Value.ToString()))
            {
                MessageBox.Show("选择的订单信息为空，选择无效，请重试");
                return;
            }

            int selectedIndex = selectedRow.Index;
            Order selectedOrder = orders[selectedIndex];

            using (OrderDetailsForm form2 = new OrderDetailsForm())
            {
                form2.OrderNumber = selectedOrder.OrderNumber;
                form2.CustomerName = selectedOrder.CustomerName;
                form2.TotalAmount = selectedOrder.TotalAmount.ToString("F2");
                foreach (var item in selectedOrder.Details)
                {
                    form2.OrderDetails.Rows.Add(item.ItemName, item.Price.ToString("F2"), item.Quantity.ToString("F0"));
                }

                if (form2.ShowDialog() == DialogResult.OK)
                {
                    selectedOrder.OrderNumber = form2.OrderNumber;
                    selectedOrder.CustomerName = form2.CustomerName;
                    selectedOrder.TotalAmount = double.TryParse(form2.TotalAmount, out double t) ? t : 0;
                    selectedOrder.Details.Clear();
                    foreach (DataGridViewRow row in form2.OrderDetails.Rows)
                    {
                        if (row.Cells[0].Value == null || string.IsNullOrWhiteSpace(row.Cells[0].Value.ToString()))
                            continue;

                        string? itemName = row.Cells[0].Value.ToString();
                        double price = double.TryParse(row.Cells[1].Value.ToString(), out double p) ? p : 0;
                        int quantity = int.TryParse(row.Cells[2].Value.ToString(), out int q) ? q : 0;

                        selectedOrder.Details.Add(new OrderItem
                        {
                            ItemName = itemName,
                            Price = price,
                            Quantity = quantity
                        });
                    }

                    dataGridView1.Rows[selectedIndex].Cells[1].Value = selectedOrder.OrderNumber;
                    dataGridView1.Rows[selectedIndex].Cells[2].Value = selectedOrder.CustomerName;
                    dataGridView1.Rows[selectedIndex].Cells[3].Value = selectedOrder.TotalAmount.ToString("F2");

                    DisplayOrderDetails(selectedOrder);
                    UpdateOrder(selectedOrder);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的订单");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            if (selectedRow.Cells[1].Value == null || string.IsNullOrWhiteSpace(selectedRow.Cells[1].Value.ToString()))
            {
                MessageBox.Show("选择的订单信息为空，选择无效，请重试");
                return;
            }

            int selectedIndex = selectedRow.Index;
            int orderId = orders[selectedIndex].Id;
            string? orderNumber = selectedRow.Cells[1].Value.ToString();

            DialogResult result = MessageBox.Show($"确定要删除订单号为 {orderNumber} 的订单吗？",
                                                  "确认删除",
                                                  MessageBoxButtons.OKCancel,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                orders.RemoveAt(selectedIndex);
                dataGridView1.Rows.RemoveAt(selectedIndex);

                int rowCount = dataGridView1.Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                }

                if (orders.Count > 0)
                {
                    dataGridView1.Rows[0].Selected = true;
                    DisplayOrderDetails(orders[0]);
                }
                else
                {
                    dataGridView2.Rows.Clear();
                }

                DeleteOrder(orderId);
            }
        }

        private void dataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < orders.Count)
            {
                DisplayOrderDetails(orders[e.RowIndex]);
            }
        }

        private void DisplayOrderDetails(Order order)
        {
            dataGridView2.Rows.Clear();
            if (order != null)
            {
                foreach (OrderItem item in order.Details)
                {
                    int rowIndex = dataGridView2.Rows.Add();
                    dataGridView2.Rows[rowIndex].Cells[0].Value = item.ItemName;
                    dataGridView2.Rows[rowIndex].Cells[1].Value = item.Price.ToString("F2");
                    dataGridView2.Rows[rowIndex].Cells[2].Value = item.Quantity.ToString("F0");
                    dataGridView2.Rows[rowIndex].Cells[3].Value = item.Subtotal.ToString("F2");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}