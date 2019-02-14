using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageQuantization
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        RGBPixel[,] ImageMatrix, ImageMatrix2;
        bool encryption = false;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
            }
            txtWidth.Text = ImageOperations.GetWidth(ImageMatrix).ToString();
            txtHeight.Text = ImageOperations.GetHeight(ImageMatrix).ToString();
        }

        private void btnGaussSmooth_Click(object sender, EventArgs e)
        {
            /*double sigma = double.Parse(txtSeed.Text);
            int maskSize = (int)nudMaskSize.Value ;
            ImageMatrix = ImageOperations.GaussianFilter1D(ImageMatrix, maskSize, sigma);
            ImageOperations.DisplayImage(ImageMatrix, pictureBox2);*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            encryption = !encryption;

            string seed = txtSeed.Text.ToString();
            int tapPosition = int.Parse(txtTapPosition.Text.ToString());
            if (encryption)
            {
                ImageMatrix2 = ImageOperations.image_encryption(ImageMatrix, seed, tapPosition);
                button1.Text = "Decryption";
            }
            else
            {
                ImageMatrix2 = ImageOperations.image_decryption(ImageMatrix2, seed, tapPosition);
                button1.Text = "Encryption";
            }
            
            ImageOperations.DisplayImage(ImageMatrix2, pictureBox2);
        }
    }
}