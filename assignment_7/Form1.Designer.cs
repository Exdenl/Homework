using System.Windows.Forms;

namespace OrderMagForm
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_create = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_sort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(644, 370);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(139, 40);
            this.btn_create.TabIndex = 0;
            this.btn_create.Text = "新建/修改";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(644, 430);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(139, 40);
            this.btn_refresh.TabIndex = 2;
            this.btn_refresh.Text = "显示全部";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(40, 30);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(743, 312);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.AutoGenerateColumns = false;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(52, 370);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(139, 40);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "删除所选项";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(243, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "按";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "订单号",
            "商品名称",
            "客户名",
            "价格"});
            this.comboBox1.Location = new System.Drawing.Point(275, 378);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(170, 26);
            this.comboBox1.TabIndex = 6;
            // 
            // btn_sort
            // 
            this.btn_sort.Location = new System.Drawing.Point(451, 370);
            this.btn_sort.Name = "btn_sort";
            this.btn_sort.Size = new System.Drawing.Size(139, 40);
            this.btn_sort.TabIndex = 7;
            this.btn_sort.Text = "排序";
            this.btn_sort.UseVisualStyleBackColor = true;
            this.btn_sort.Click += new System.EventHandler(this.btn_sort_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(828, 494);
            this.Controls.Add(this.btn_sort);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.btn_create);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "订单管理";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_create;
        private Button btn_refresh;
        private DataGridView dataGridView1;
        private Button btn_delete;
        private Label label1;
        private ComboBox comboBox1;
        private Button btn_sort;
    }

    partial class SubForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.price = new System.Windows.Forms.Label();
            this.priceBox = new System.Windows.Forms.TextBox();
            this.client = new System.Windows.Forms.Label();
            this.obname = new System.Windows.Forms.Label();
            this.clientBox = new System.Windows.Forms.TextBox();
            this.obnameBox = new System.Windows.Forms.TextBox();
            this.idBox = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.Label();
            // 
            // price
            // 
            this.price.AllowDrop = true;
            this.price.AutoSize = true;
            this.price.Location = new System.Drawing.Point(622, 18);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(62, 18);
            this.price.TabIndex = 6;
            this.price.Text = "价格：";
            // 
            // priceBox
            // 
            this.priceBox.Location = new System.Drawing.Point(674, 18);
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(128, 28);
            this.priceBox.TabIndex = 7;
            // 
            // client
            // 
            this.client.AutoSize = true;
            this.client.Location = new System.Drawing.Point(423, 18);
            this.client.Name = "client";
            this.client.Size = new System.Drawing.Size(80, 18);
            this.client.TabIndex = 8;
            this.client.Text = "客户名：";
            // 
            // obname
            // 
            this.obname.AutoSize = true;
            this.obname.Location = new System.Drawing.Point(197, 18);
            this.obname.Name = "obname";
            this.obname.Size = new System.Drawing.Size(98, 18);
            this.obname.TabIndex = 9;
            this.obname.Text = "商品名称：";
            // 
            // clientBox
            // 
            this.clientBox.Location = new System.Drawing.Point(489, 18);
            this.clientBox.Name = "clientBox";
            this.clientBox.Size = new System.Drawing.Size(128, 28);
            this.clientBox.TabIndex = 10;
            // 
            // obnameBox
            // 
            this.obnameBox.Location = new System.Drawing.Point(290, 18);
            this.obnameBox.Name = "obnameBox";
            this.obnameBox.Size = new System.Drawing.Size(128, 28);
            this.obnameBox.TabIndex = 11;
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(63, 18);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(128, 28);
            this.idBox.TabIndex = 12;
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(22, 18);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(35, 18);
            this.id.TabIndex = 13;
            this.id.Text = "id:";
            //
            //btn_create
            //
            this.btn_create = new System.Windows.Forms.Button();
            this.btn_create.Location = new System.Drawing.Point(646, 52);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(139, 40);
            this.btn_create.TabIndex = 0;
            this.btn_create.Text = "新建";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            //
            //btn_change
            //
            this.btn_change = new System.Windows.Forms.Button();
            this.btn_change.Location = new System.Drawing.Point(448, 52);
            this.btn_change.Name = "btn_change";
            this.btn_change.Size = new System.Drawing.Size(139, 40);
            this.btn_change.TabIndex = 0;
            this.btn_change.Text = "修改";
            this.btn_change.UseVisualStyleBackColor = true;
            this.btn_change.Click += new System.EventHandler(this.btn_change_Click);
            //
            //btn_find
            //
            this.btn_find = new System.Windows.Forms.Button();
            this.btn_find.Location = new System.Drawing.Point(250, 52);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(139, 40);
            this.btn_find.TabIndex = 0;
            this.btn_find.Text = "查找";
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // SubForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new System.Drawing.Size(850, 140);
            this.Name = "SubForm";
            this.Text = "订单增改";
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.btn_change);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.id);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.obnameBox);
            this.Controls.Add(this.clientBox);
            this.Controls.Add(this.obname);
            this.Controls.Add(this.client);
            this.Controls.Add(this.priceBox);
            this.Controls.Add(this.price);

            this.Load += new System.EventHandler(this.SubForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Button btn_change;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.Label price;
        private System.Windows.Forms.TextBox priceBox;
        private System.Windows.Forms.Label client;
        private System.Windows.Forms.Label obname;
        private System.Windows.Forms.TextBox clientBox;
        private System.Windows.Forms.TextBox obnameBox;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Label id;
    }
}

