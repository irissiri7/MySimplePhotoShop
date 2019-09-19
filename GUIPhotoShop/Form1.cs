using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GUIPhotoShop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        string pathOriginalImage;
        string pathModifiedImage;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                pathOriginalImage = OpenFile.FileName;
                pictureBox1.Image = Image.FromFile(pathOriginalImage);
                OpenFile.Dispose();
            }
        }

        private void Button_1_Click(object sender, EventArgs e)
        {
            string newFile = PhotoShopLib.ImageEditor.MakeNegative(pathOriginalImage);
            pathModifiedImage = newFile;

            pictureBox2.Image = Image.FromFile(newFile);
            pictureBox2.Dispose();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string newFile = PhotoShopLib.ImageEditor.MakeBlackAndWhite(pathOriginalImage);
            pictureBox2.Image = Image.FromFile(newFile);
            pictureBox2.Dispose();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string newFile = PhotoShopLib.ImageEditor.MakeBlurr(pathOriginalImage);
            pictureBox2.Image = Image.FromFile(newFile);
            pictureBox2.Dispose();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = pathModifiedImage;

            if (save.ShowDialog() == DialogResult.OK)
            {
                BinaryWriter bw = new BinaryWriter(File.Create(pathModifiedImage));
                
                bw.Dispose();
            }
        }
    }
}
