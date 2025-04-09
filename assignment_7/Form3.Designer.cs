namespace Week6
{
    partial class Form3
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            textBox3 = new TextBox();
            label3 = new Label();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(239, 200);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(590, 38);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(239, 308);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(590, 38);
            textBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 203);
            label1.Name = "label1";
            label1.Size = new Size(110, 31);
            label1.TabIndex = 3;
            label1.Text = "顾客姓名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 311);
            label2.Name = "label2";
            label2.Size = new Size(110, 31);
            label2.TabIndex = 4;
            label2.Text = "货品名称";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft YaHei UI", 12F);
            label4.Location = new Point(335, 62);
            label4.Name = "label4";
            label4.Size = new Size(242, 41);
            label4.TabIndex = 6;
            label4.Text = "请录入订单信息";
            // 
            // button1
            // 
            button1.Location = new Point(513, 474);
            button1.Name = "button1";
            button1.Size = new Size(150, 46);
            button1.TabIndex = 7;
            button1.Text = "取消";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(239, 474);
            button2.Name = "button2";
            button2.Size = new Size(150, 46);
            button2.TabIndex = 8;
            button2.Text = "提交";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(217, 105);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(584, 38);
            textBox3.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(79, 108);
            label3.Name = "label3";
            label3.Size = new Size(86, 31);
            label3.TabIndex = 1;
            label3.Text = "订单号";
            label3.Click += label3_Click;
            // 
            // button3
            // 
            button3.Location = new Point(217, 280);
            button3.Name = "button3";
            button3.Size = new Size(150, 46);
            button3.TabIndex = 2;
            button3.Text = "删除";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(497, 280);
            button4.Name = "button4";
            button4.Size = new Size(150, 46);
            button4.TabIndex = 3;
            button4.Text = "取消";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form3
            // 
            ClientSize = new Size(926, 585);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Name = "Form3";
            Text = "删除订单";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label4;
        private Button button1;
        private Button button2;
        private TextBox textBox3;
        private Label label3;
        private Button button3;
        private Button button4;
    }
}
