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
        Bitmap originalImage;
        Bitmap modifiedImage;

        private void Button_Open(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG)|*.bmp;*.jpg;*.gif;*.png";

            if (open.ShowDialog() == DialogResult.OK)
            {
                originalPath = open.FileName;
                bool isFileValid = InputHandler.CheckIfValidInput(originalPath, out string message);

                if (isFileValid == false)
                {
                    MessageBox.Show(message);
                }
                else
                {
                    originalImage = new Bitmap(originalPath);
                    pictureBox1.Image = Image.FromFile(open.FileName);
                }
            }
        }

        private void Button_Negative(object sender, EventArgs e)
        {
            modifiedImage = ImageEditor.MakeNegative(originalImage, originalPath, out pathModifiedImage);

            pictureBox2.Image = modifiedImage;
            
        }

        private void Button_BlackAndWhite(object sender, EventArgs e)
        {
            modifiedImage = ImageEditor.MakeBlackAndWhite(originalImage, originalPath, out pathModifiedImage);

            pictureBox2.Image = modifiedImage;

        }

        private void Button_Blurr(object sender, EventArgs e)
        {
            modifiedImage = ImageEditor.MakeBlurr(originalImage, originalPath, out pathModifiedImage);

            pictureBox2.Image = modifiedImage;

        }

        private void Button_Save(object sender, EventArgs e)
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
