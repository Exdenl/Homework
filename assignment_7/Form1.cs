namespace Week6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Order.OrderCreated += OnOrderCreated;
        }

        private void OnOrderCreated(Order newOrder)
        {
            string data = $"新的订单已创建，订单号为{newOrder.OrderId}";
            MessageBox.Show(data);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             Form5 frm5 = new Form5();
            frm5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
        }
    }
}
