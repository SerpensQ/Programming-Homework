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

           

            //LoadPicture((Bitmap)Image.FromFile("Pear.jpg"));
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
            //Bitmap originalphoto = new Bitmap(pictureBoxOriginal.Image);
            //Bitmap resultphoto = new Bitmap(originalphoto.Width, originalphoto.Height);

            //var filter = comboBoxFilters.SelectedItem as IFilter;
            //var parameters = new double[parameterControls.Count];
            //for (var i = 0; i < parameters.Length; i++)
            //    parameters[i] = (double)parameterControls[i].Value;

            //resultPhoto = filter.Process(originalPhoto, parameters);
            //pictureBoxResult.Image = Convertors.PhotoToBitmap(resultPhoto);  ПОПЫТКА ДЗ

            var filter = comboBoxFilters.SelectedItem as IFilter;
            var parameters = new double[parameterControls.Count];
            for (var i = 0; i < parameters.Length; i++)
                parameters[i] = (double)parameterControls[i].Value;

            resultPhoto = filter.Process(originalPhoto, parameters);
            pictureBoxResult.Image = Convertors.PhotoToBitmap(resultPhoto);
            saveToolStripMenuItem.Enabled = true;
        }

        private void LoadPicture(Bitmap bmp)
        {
            originalPhoto = Convertors.BitmapToPhoto(bmp);
            pictureBoxOriginal.Image = bmp;
            pictureBoxResult.Image = null;

        }

        private void SavePicture(Photo photo, string filename)
        {
            var bmp = Convertors.PhotoToBitmap(photo);
            bmp.Save(filename,System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        public void AddFilter(IFilter filter)
        {
            comboBoxFilters.Items.Add(filter);
            
        }

        //private void UploadButton_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog upload = new OpenFileDialog();

        //    upload.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";

        //    if (upload.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            pictureBoxOriginal.Image = new Bitmap(upload.FileName);
        //        }
        //        catch
        //        {
        //            MessageBox.Show("Unable to upload this file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}

        //private void SaveButton_Click(object sender, EventArgs e)
        //{
        //    if (pictureBoxOriginal.Image != null)
        //    {
        //        SaveFileDialog save = new SaveFileDialog();
        //        save.Title = "Save image as...";
        //        save.OverwritePrompt = true;
        //        save.CheckPathExists = true;
        //        save.Filter = "Image files(*.BMP)|*.BMP|Image files(*.JPG)|*.JPG|Image files(*.PNG)|*.PNG|All files(*.*)|*.*";

        //        if (save.ShowDialog() == DialogResult.OK)
        //        {
        //            try
        //            {
        //                pictureBoxOriginal.Image.Save(save.FileName);
        //            }
        //            catch
        //            {
        //                MessageBox.Show("Unable to save this image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }


        //    }
        //}

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                buttonApply.Visible = true;
                comboBoxFilters.Visible = true;

                if (comboBoxFilters.SelectedIndex == -1)
                    comboBoxFilters.SelectedIndex = 0;

                LoadPicture((Bitmap)Image.FromFile(openFileDialog1.FileName));
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPEG)|*.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                SavePicture(resultPhoto, saveFileDialog1.FileName);
        }
    }
}
