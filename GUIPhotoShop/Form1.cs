using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PhotoShopLib;

namespace GUIPhotoShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        static string originalPath;
        static string pathModifiedImage;
        Bitmap modifiedImage;

        private void Button1_Click(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                originalPath = OpenFile.FileName;
                pictureBox1.Image = Image.FromFile(originalPath);
                //?
                OpenFile.Dispose();
            }
        }

        //NegativeButton
        private void Button_1_Click(object sender, EventArgs e)
        {
            Bitmap originalImage = new Bitmap(originalPath); 
            modifiedImage = ImageEditor.MakeNegative(originalImage, originalPath, out pathModifiedImage);

            pictureBox2.Image = modifiedImage;
            
        }

        //BlackAndWhiteButton
        private void Button4_Click(object sender, EventArgs e)
        {
            Bitmap originalImage = new Bitmap(originalPath);
            modifiedImage = ImageEditor.MakeBlackAndWhite(originalImage, originalPath, out pathModifiedImage);

            pictureBox2.Image = modifiedImage;

        }

        //BlurrButton
        private void Button5_Click(object sender, EventArgs e)
        {
            Bitmap originalImage = new Bitmap(originalPath);
            modifiedImage = ImageEditor.MakeBlurr(originalImage, originalPath, out pathModifiedImage);

            pictureBox2.Image = modifiedImage;

        }

        //This only works if i don't change the filename
        private void Button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = Path.GetFileName(pathModifiedImage);

            if (save.ShowDialog() == DialogResult.OK)
            {
                modifiedImage.Save(pathModifiedImage);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
