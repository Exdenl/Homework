using MySql.Data.MySqlClient;
using OrderMagForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManagement
{
    public partial class MainForm : Form
    {
        private readonly DatabaseHandler dbHandler = new DatabaseHandler();
        private readonly SubForm subForm = new SubForm();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dataGridViewOrders.DataSource = dbHandler.FetchAllOrders().Tables[0];
        }

        private void btnCreateModify_Click(object sender, EventArgs e)
        {
            subForm.OrderCreated += SubForm_OrderCreated;
            subForm.OrderSearched += SubForm_OrderSearched;
            subForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrders.CurrentRow != null)
            {
                var id = dataGridViewOrders.CurrentRow.Cells["id"].Value.ToString();
                dbHandler.RemoveOrder(id);
                RefreshGrid();
            }
            else
            {
                MessageBox.Show("请选择要删除的行。");
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (comboBoxSort.SelectedIndex == -1)
            {
                MessageBox.Show("请选择排序依据。");
                return;
            }

            string[] columns = { "id", "obname", "client", "price" };
            dataGridViewOrders.DataSource = dbHandler.SortOrders(columns[comboBoxSort.SelectedIndex]).Tables[0];
        }

        private void SubForm_OrderCreated(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void SubForm_OrderSearched(object sender, DataSet e)
        {
            dataGridViewOrders.DataSource = e.Tables[0];
        }
    }

    public partial class SubForm : Form
    {
        public event EventHandler OrderCreated;
        public event EventHandler<DataSet> OrderSearched;
        private readonly DatabaseHandler dbHandler = new DatabaseHandler();

        public SubForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                dbHandler.InsertOrder(txtID.Text, txtProductName.Text, txtClient.Text, double.Parse(txtPrice.Text));
                MessageBox.Show("订单创建成功！");
                OrderCreated?.Invoke(this, EventArgs.Empty);
            }
            catch (FormatException)
            {
                MessageBox.Show("价格输入格式错误。");
            }
            catch (OperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                double? price = string.IsNullOrWhiteSpace(txtPrice.Text) ? (double?)null : double.Parse(txtPrice.Text);
                dbHandler.UpdateOrder(txtID.Text, txtProductName.Text, txtClient.Text, price);
                MessageBox.Show("订单修改成功！");
                OrderCreated?.Invoke(this, EventArgs.Empty);
            }
            catch (FormatException)
            {
                MessageBox.Show("价格输入格式错误。");
            }
            catch (OperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                double? price = string.IsNullOrWhiteSpace(txtPrice.Text) ? (double?)null : double.Parse(txtPrice.Text);
                var result = dbHandler.SearchOrders(txtID.Text, txtProductName.Text, txtClient.Text, price);
                OrderSearched?.Invoke(this, result);
            }
            catch (FormatException)
            {
                MessageBox.Show("价格输入格式错误。");
            }
            catch (OperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
