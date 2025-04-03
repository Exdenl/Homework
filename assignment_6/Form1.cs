using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json; 

namespace WinForm_test
{
    public partial class Form1 : Form
    {
        private class Order
        {
            public string? OrderNumber { get; set; }
            public string? CustomerName { get; set; }
            public double TotalAmount { get; set; }
            public List<OrderItem> Details { get; set; } = new List<OrderItem>();

        }

        private class OrderItem
        {
            public string? ItemName { get; set; }
            public double Price { get; set; }
            public double Quantity { get; set; }
            public double Subtotal => Price * Quantity;
        }

        private List<Order> orders = new List<Order>();
        private string filePath = Path.Combine(Application.StartupPath, "orders.json");

        public Form1()
        {
            InitializeComponent();

            dataGridView1.CellClick += dataGridView1_CellContentClick;

            LoadOrders();

        }
        private void LoadOrders()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                orders = JsonConvert.DeserializeObject<List<Order>>(json) ?? new List<Order>();

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
        }

        private void SaveOrders()
        {
            string json = JsonConvert.SerializeObject(orders, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
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
                        double quantity = double.TryParse(row.Cells[2].Value.ToString(), out double q) ? q : 0;

                        newOrder.Details.Add(new OrderItem
                        {
                            ItemName = itemName,
                            Price = price,
                            Quantity = quantity
                        });
                    }
                    
                    orders.Add(newOrder);

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

                    SaveOrders();
                }
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要修改的订单！");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            if (selectedRow.Cells[1].Value == null || string.IsNullOrWhiteSpace(selectedRow.Cells[1].Value.ToString()))
            {
                MessageBox.Show("选中的订单信息为空，请选择有效订单！");
                return;
            }

            int selectedIndex = selectedRow.Index;
            Order selectedOrder = orders[selectedIndex];

            using (Form2 form2 = new Form2())
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
                        double quantity = double.TryParse(row.Cells[2].Value.ToString(), out double q) ? q : 0;

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

                    SaveOrders();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的订单！");
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            if (selectedRow.Cells[1].Value == null || string.IsNullOrWhiteSpace(selectedRow.Cells[1].Value.ToString()))
            {
                MessageBox.Show("选中的订单信息为空，请选择有效订单！");
                return;
            }

            int selectedIndex = selectedRow.Index;
            string? orderNumber = selectedRow.Cells[1].Value.ToString();

            DialogResult result = MessageBox.Show($"你确定要删除编号为 {orderNumber} 的订单吗？",
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
            }
        }
    }
}
