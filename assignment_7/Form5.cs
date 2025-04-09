using System.Windows.Forms;

namespace Week6
{

    public partial class Form5 : Form
    {

        public event Action<string> OnDataReady;


        public Form5()
        {
            InitializeComponent();
        }





        private void label3_Click(object sender, EventArgs e)
        {

        }



        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(133, 103);
            label1.Name = "label1";
            label1.Size = new Size(111, 31);
            label1.TabIndex = 0;
            label1.Text = "原订单ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(133, 198);
            label2.Name = "label2";
            label2.Size = new Size(134, 31);
            label2.TabIndex = 1;
            label2.Text = "新顾客姓名";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(133, 295);
            label3.Name = "label3";
            label3.Size = new Size(134, 31);
            label3.TabIndex = 2;
            label3.Text = "新货品名称";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(359, 100);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(360, 38);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(359, 195);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(360, 38);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(359, 292);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(360, 38);
            textBox3.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(483, 434);
            button2.Name = "button2";
            button2.Size = new Size(150, 46);
            button2.TabIndex = 7;
            button2.Text = "取消";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(215, 434);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 8;
            button1.Text = "修改";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form5
            // 
            ClientSize = new Size(926, 595);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form5";
            Text = "修改订单";
            ResumeLayout(false);
            PerformLayout();

        }

        private void Form5_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0) { MessageBox.Show("输入信息不完整，请重试"); }
            else
            {
                int text1 = int.Parse(textBox1.Text);
                string text2 = textBox2.Text;
                string text3 = textBox3.Text;
                Program.orderService.ChangeAOrderById(text1, text2, text3);

                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
