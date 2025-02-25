using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cmbOperator.SelectedIndex = 0;
        }

        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            try
            {
                double num1 = Convert.ToDouble(txtNum1.Text);
                double num2 = Convert.ToDouble(txtNum2.Text);
                string oper = cmbOperator.SelectedItem.ToString();

                double result = 0;
                bool canCal = true;

                switch (oper)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 == 0)
                        {
                            MessageBox.Show("除数不能为零！");
                            canCal = false;
                        }
                        else
                        {
                            result = num1 / num2;
                        }
                        break;
                    default:
                        MessageBox.Show("无效的运算符！");
                        canCal = false;
                        break;
                }

                if (canCal)
                {
                    lblResult.Text = $"结果: {result}";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("请输入有效的数字！");
            }
        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }
    }

}
