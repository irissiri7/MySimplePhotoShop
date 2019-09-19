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


        string path;
        private void Button1_Click(object sender, EventArgs e)
        {

            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                path = OpenFile.FileName;
                pictureBox1.Image = Image.FromFile(path);
            }

        }

        private void Making_Negative(object sender, EventArgs e)
        {
            string newFile = PhotoShopLib.ImageEditor.MakeNegative(path);
            pictureBox2.Image = Image.FromFile(newFile);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string newFile = PhotoShopLib.ImageEditor.MakeBlackAndWhite(path);
            pictureBox2.Image = Image.FromFile(newFile);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string newFile = PhotoShopLib.ImageEditor.MakeBlurr(path);
            pictureBox2.Image = Image.FromFile(newFile);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string newFile = PhotoShopLib.ImageEditor.MakeNegative(path);
            pictureBox2.Image = Image.FromFile(newFile);
        }

    }
}
