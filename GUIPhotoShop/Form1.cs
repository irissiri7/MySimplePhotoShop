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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Variables that should be accessible between different buttonclicks
        static string originalPath;
        static string pathModifiedImage;
        Bitmap modifiedImage;

        //Opening the original image.
        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG)|*.bmp;*.jpg;*.gif;*.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                originalPath = open.FileName;
                pictureBox1.Image = Image.FromFile(open.FileName);
            }
        }

        //Making a negative copy
        private void Button_1_Click(object sender, EventArgs e)
        {
            Bitmap originalImage = new Bitmap(originalPath); 
            modifiedImage = ImageEditor.MakeNegative(originalImage, originalPath, out pathModifiedImage);

            pictureBox2.Image = modifiedImage;
            
        }

        //Making a black and white copy
        private void Button4_Click(object sender, EventArgs e)
        {
            Bitmap originalImage = new Bitmap(originalPath);
            modifiedImage = ImageEditor.MakeBlackAndWhite(originalImage, originalPath, out pathModifiedImage);

            pictureBox2.Image = modifiedImage;

        }

        //Making a blurr copy
        private void Button5_Click(object sender, EventArgs e)
        {
            Bitmap originalImage = new Bitmap(originalPath);
            modifiedImage = ImageEditor.MakeBlurr(originalImage, originalPath, out pathModifiedImage);

            pictureBox2.Image = modifiedImage;

        }

        //Saving the copy
        private void Button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG)|*.bmp;*.jpg;*.gif;*.png";
            save.FileName = Path.GetFileName(pathModifiedImage);
            
            if (save.ShowDialog() == DialogResult.OK)
            {
                modifiedImage.Save(save.FileName);
            }

        }

        
    }
}
