using System.Windows.Forms;

namespace Week6
{

    public partial class Form4 : Form
    {

        public event Action<string> OnDataReady;


        public Form4()
        {
            InitializeComponent();
        }



        private void Form4_Load(object sender, EventArgs e)
        {

        }



        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(85, 129);
            label1.Name = "label1";
            label1.Size = new Size(111, 31);
            label1.TabIndex = 0;
            label1.Text = "订单号ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 228);
            label2.Name = "label2";
            label2.Size = new Size(110, 31);
            label2.TabIndex = 1;
            label2.Text = "货物名称";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 320);
            label3.Name = "label3";
            label3.Size = new Size(110, 31);
            label3.TabIndex = 2;
            label3.Text = "顾客姓名";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlDark;
            label4.Location = new Point(85, 44);
            label4.Name = "label4";
            label4.Size = new Size(710, 31);
            label4.TabIndex = 3;
            label4.Text = "检索功能提供三种检索形式，只需填写一个单元格并点击检索按键";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(237, 129);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(418, 38);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(237, 225);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(418, 38);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(237, 320);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(418, 38);
            textBox3.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(215, 432);
            button1.Name = "button1";
            button1.Size = new Size(128, 56);
            button1.TabIndex = 7;
            button1.Text = "检索";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(449, 432);
            button2.Name = "button2";
            button2.Size = new Size(128, 56);
            button2.TabIndex = 8;
            button2.Text = "取消";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form4
            // 
            ClientSize = new Size(850, 561);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form4";
            Text = "查询订单";
            ResumeLayout(false);
            PerformLayout();

        }
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {
                Program.orderService.FindAOrderById(int.Parse(textBox1.Text));
            }
            else if (textBox2.Text.Length != 0)
            {
                Program.orderService.FindAOrderByGoodsname(textBox2.Text);
            }
            else if (textBox3.Text.Length != 0)
            {
                Program.orderService.FindAOrderByCustomer(textBox3.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
