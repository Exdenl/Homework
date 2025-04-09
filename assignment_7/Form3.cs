using System.Windows.Forms;

namespace Week6
{

    public partial class Form3 : Form
    {

        public event Action<string> OnDataReady;


        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string text1 = textBox1.Text;
            string text2 = textBox2.Text;
            Program.orderService.AddOrder(text1, text2);
            string data = "订单已删除";
            OnDataReady?.Invoke(data); // 触发事件
            this.Close(); // 
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int text1 = int.Parse(textBox3.Text);

            Program.orderService.DeleteOrder(text1);
            
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
