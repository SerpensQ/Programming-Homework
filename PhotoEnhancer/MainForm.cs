using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEnhancer
{
    public partial class MainForm : Form
    {
        Panel parametersPanel;
        Bitmap originalBMP;
        Bitmap resultBMP; 
        public MainForm()
        {
            InitializeComponent();

            comboBoxFilters.Items.Add("Brighter | Darker");
            comboBoxFilters.Items.Add("");


            //pictureBoxOriginal.Image = Image.FromFile("Pear.jpg");
            originalBMP=(Bitmap)Image.FromFile("Pear.jpg");
            pictureBoxOriginal.Image = originalBMP;
        }

        private void comboBoxFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (parametersPanel != null)
                this.Controls.Remove(parametersPanel);

            parametersPanel = new Panel();

            parametersPanel.Left = comboBoxFilters.Left;
            parametersPanel.Width = comboBoxFilters.Width;
            parametersPanel.Top = comboBoxFilters.Bottom+10;
            parametersPanel.Height = buttonApply.Top - comboBoxFilters.Bottom - 20;
            parametersPanel.BackColor = Color.BlanchedAlmond;


            var filter = comboBoxFilters.SelectedItem;

            if (filter.ToString()== "Brighter | Darker")
            {
                //MessageBox.Show("Brightening | darkening filter");
                //parametersPanel.BackColor = Color.DarkSlateBlue;

                var label = new Label();
                label.Left = 0;
                label.Top = 0;
                label.Width = parametersPanel.Width - 50;
                label.Height = 20;
                label.Text = "coefficient";
                parametersPanel.Controls.Add(label);

                var inputBox = new NumericUpDown();
                inputBox.Left = label.Right;
                inputBox.Top = label.Top;
                inputBox.Width = 50;
                inputBox.Height = 20;
                inputBox.Minimum = 0;
                inputBox.Maximum = 10;
                inputBox.Increment = (Decimal)0.05;
                inputBox.DecimalPlaces = 2;
                inputBox.Value = 1;
                inputBox.Name = "coefficient";
                parametersPanel.Controls.Add(inputBox);
            }
            else
            {
               // parametersPanel.BackColor=this.BackColor;
            }
            Controls.Add(parametersPanel);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            var newBMP = new Bitmap(originalBMP.Width, originalBMP.Height);
            //using (var g = Graphics.FromImage(newBMP))
            //{
            //    g.DrawImage(resultBMP, new Rectangle(0, 0, newBMP.Width, newBMP.Height);

                if(comboBoxFilters.SelectedItem.ToString() == "Brighter | Darker")
                {
                    for(int x=0; x<originalBMP.Width; x++)
                        for (int y=0; y<originalBMP.Height; y++)
                        {
                            
                        var pixelColor = originalBMP.GetPixel(x, y);

                        var k = (double)((NumericUpDown)parametersPanel.Controls["coefficient"]).Value;

                        var newR = (int)(pixelColor.R*k);
                        if (newR > 255) newR = 255;

                        var newG = (int)(pixelColor.G * k);
                        if (newG > 255) newG = 255;

                        var newB = (int)(pixelColor.B * k);
                        if (newB > 255) newB = 255;

                        var newColor = new Color();

                        newBMP.SetPixel(x, y, Color.FromArgb(newR, newG, newB));

                    }

                }
            //}


            resultBMP = newBMP;
            pictureBoxResult.Image = resultBMP;
        }
    }
}
