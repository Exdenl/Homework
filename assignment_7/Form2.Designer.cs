namespace Week6
{
    partial class Form2
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
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 311);
            label2.Name = "label2";
            label2.Size = new Size(110, 31);
            label2.TabIndex = 4;
            label2.Text = "货品名称";
            label2.Click += label2_Click;
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
            label4.Click += label4_Click;
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
            // Form2
            // 
            ClientSize = new Size(926, 585);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Form2";
            Text = "创建订单";
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
    }
}
