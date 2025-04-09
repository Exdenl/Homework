using System.Windows.Forms;

namespace Week6
{

    public partial class Form2 : Form
    {

        public event Action<string> OnDataReady;

        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 || textBox2.Text.Length != 0)
            {
                string text1 = textBox1.Text;
                string text2 = textBox2.Text;
                Program.orderService.AddOrder(text1, text2);
                string data = "新的订单已创建";
                OnDataReady?.Invoke(data); // 触发事件
                this.Close();
            }
            else { MessageBox.Show("输入的信息有缺失"); }
        }
    }
}
