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
        Photo originalPhoto;
        Photo resultPhoto;
        List<NumericUpDown> parameterControls;
        public MainForm()
        {
            InitializeComponent();

            //comboBoxFilters.Items.Add("Brighter | Darker");


           
            LoadPicture((Bitmap)Image.FromFile("Pear.jpg"));
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


            var filter = comboBoxFilters.SelectedItem as IFilter;
            if (filter == null)
                return;
            else
            {
                parameterControls = new List<NumericUpDown>();
                var paramsInfo = filter.GetParemeterInfo();
                for(var i=0; i<paramsInfo.Length; i++)
                {
                    var label = new Label();
                    label.Height = 20;
                    label.Width = parametersPanel.Width - 50;
               
                    label.Left = 0;
                    label.Top = i * (label.Height + 10);
                    label.Text = paramsInfo[i].Name;
                    parametersPanel.Controls.Add(label);

                    var inputBox = new NumericUpDown();
                    inputBox.Width = 50;
                    inputBox.Height = label.Height;
                    inputBox.Top = label.Top;
                    inputBox.Left = label.Right;
                    inputBox.DecimalPlaces = 2;
                    inputBox.Minimum =(decimal)paramsInfo[i].MinValue;
                    inputBox.Minimum = (decimal)paramsInfo[i].MaxValue;
                    inputBox.Increment = (decimal)paramsInfo[i].Increment;
                    inputBox.Value = (decimal)paramsInfo[i].DefaultValue;
                    parameterControls.Add(inputBox);
                    parametersPanel.Controls.Add(inputBox);

                }

            }


            //if (filter.ToString()== "Brighter | Darker")
            //{
               
            //    var label = new Label();
            //    label.Left = 0;
            //    label.Top = 0;
            //    label.Width = parametersPanel.Width - 50;
            //    label.Height = 20;
            //    label.Text = "coefficient";
            //    parametersPanel.Controls.Add(label);

            //    var inputBox = new NumericUpDown();
            //    inputBox.Left = label.Right;
            //    inputBox.Top = label.Top;
            //    inputBox.Width = 50;
            //    inputBox.Height = 20;
            //    inputBox.Minimum = 0;
            //    inputBox.Maximum = 10;
            //    inputBox.Increment = (Decimal)0.05;
            //    inputBox.DecimalPlaces = 2;
            //    inputBox.Value = 1;
            //    inputBox.Name = "coefficient";
            //    parametersPanel.Controls.Add(inputBox);
            //}
            //else
            //{
            //   // parametersPanel.BackColor=this.BackColor;
            //}
            Controls.Add(parametersPanel);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            var newPhoto = new Photo(originalPhoto.Width, originalPhoto.Height);


                if(comboBoxFilters.SelectedItem.ToString() == "Brighter | Darker")
                {
                var k = (double)((NumericUpDown)parametersPanel.Controls["coefficient"]).Value;
                for (int x=0; x<originalPhoto.Width; x++)
                        for (int y=0; y<originalPhoto.Height; y++)
                        {



                        newPhoto[x, y] = originalPhoto[x, y] * k;
                    }

               
                }

            resultPhoto = newPhoto;
            pictureBoxResult.Image = Convertors.PhotoToBitmap(resultPhoto);
        }

        private void LoadPicture(Bitmap bmp)
        {
            originalPhoto = Convertors.BitmapToPhoto(bmp);
            pictureBoxOriginal.Image = bmp;
            pictureBoxResult.Image = null;

        }

        public void AddFilter(IFilter filter)
        {
            comboBoxFilters.Items.Add(filter);
            if (comboBoxFilters.SelectedIndex == -1)
                comboBoxFilters.SelectedIndex = 0;

        }
    }
}
