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

            //comboBoxFilters.Items.Add("Осветление/затемнение");

            LoadPicture((Bitmap)Image.FromFile("Pear.jpg"));
        }

        private void comboBoxFilters_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (parametersPanel != null)
                this.Controls.Remove(parametersPanel);

            parametersPanel = new Panel();

            parametersPanel.Left = comboBoxFilters.Left;
            parametersPanel.Width = comboBoxFilters.Width;
            parametersPanel.Top = comboBoxFilters.Bottom + 10;
            parametersPanel.Height = buttonApply.Top - comboBoxFilters.Bottom - 20;

            var filter = comboBoxFilters.SelectedItem as IFilter;

            if (filter == null)
                return;
            else
            {
                parameterControls = new List<NumericUpDown>();

                var paramsInfo = filter.GetParemeterInfo();
                for (var i = 0; i < paramsInfo.Length; i++)
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
                    inputBox.Left = label.Right;
                    inputBox.Top = label.Top;
                    inputBox.DecimalPlaces = 2;
                    inputBox.Minimum = (decimal)paramsInfo[i].MinValue;
                    inputBox.Maximum = (decimal)paramsInfo[i].MaxValue;
                    inputBox.Increment = (decimal)paramsInfo[i].Increment;
                    inputBox.Value = (decimal)paramsInfo[i].DefaultValue;
                    parameterControls.Add(inputBox);
                    parametersPanel.Controls.Add(inputBox);
                }
            }

            this.Controls.Add(parametersPanel);
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            //var newPhoto = new Photo(originalPhoto.Width, originalPhoto.Height);

            //if(comboBoxFilters.SelectedItem.ToString() == "Осветление/затемнение")
            //{
            // var k = (double)((NumericUpDown)parametresPanel.Controls["coefficient"]).Value;

            // for (int x = 0; x < originalPhoto.Width; x++)
            // for(int y = 0; y < originalPhoto.Height; y++)
            // {
            // newPhoto[x, y] = originalPhoto[x, y] * k;
            // }
            //}
            var filter = comboBoxFilters.SelectedItem as IFilter;
            var parameters = new double[parameterControls.Count];
            for (var i = 0; i < parameters.Length; i++)
                parameters[i] = (double)parameterControls[i].Value;

            resultPhoto = filter.Process(originalPhoto, parameters);
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
