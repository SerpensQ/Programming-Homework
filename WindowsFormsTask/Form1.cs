using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            comboBox1.Items.Add("АИ-92");
            comboBox1.Items.Add("АИ-95");
            comboBox1.Items.Add("АИ-98");
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label4.Text = "42,4";
            }
            if (comboBox1.SelectedIndex == 1)
            {
                label4.Text = "46,6";
            }

            if (comboBox1.SelectedIndex == 2)
            {
                label4.Text = "51,8";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int liters = (int)numericUpDown1.Value;
            double fuelprice = Double.Parse(label4.Text);
            double finalcost = fuelprice * liters;
            label5.Text = finalcost.ToString()+ " руб.";
        }
    }
}
