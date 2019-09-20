using NUnit.Framework;
using PhotoShopLib;
using System.Drawing;

namespace Tests
{
    public class Tests
    {


        //TESTING THE IMAGEEDITOR
        [Test]
        public void ImageEditor_MakeNegative_IsNegative()
        {
            string testImagePath = @"testImages\puppy.jpg";

            Bitmap testImageOriginal = new Bitmap(testImagePath);
            Bitmap testImageClone = (Bitmap)testImageOriginal.Clone();

            
            Color testImageColor = Color.FromArgb(100, 50, 150);
            testImageOriginal.SetPixel(1, 1, testImageColor);
            ImageEditor.MakeNegative(tes)
            

        }

        //TESTING THE INPUTHANDLER
        [Test]
        public void CheckInput_TooBigImage_ReturnsFalse()
        {
            string testImage = @"testImages\TooBigDog.jpg";
            bool resultOfBigImage = InputHandler.CheckIfValidInput(testImage, out string message);
            Assert.AreEqual(false, resultOfBigImage);
        }
        [Test]
        public void CheckInput_TooSmallImage_ReturnsFalse()
        {
            string testImage = @"testImages\TooSmall.jpg";
            bool resultOfBigImage = InputHandler.CheckIfValidInput(testImage, out string message);
            Assert.AreEqual(false, resultOfBigImage);
        }

        [Test]
        public void CheckInput_WrongFormat_ReturnsFalse()
        {
            string testImage = @"testImages\WrongFormat.gif";
            bool resultOfBigImage = InputHandler.CheckIfValidInput(testImage, out string message);
            Assert.AreEqual(false, resultOfBigImage);
        }

        //TESTING THE FILENAMEEDITOR
        [Test]
        public void FileNameEditor_HappyDays_ReturnsString()
        {
            string testImage = @"C:\Users\lydia\Desktop\puppy.jpg";
            string testString = PhotoShopLib.FileNameEditor.AddSuffixToFileName(testImage, "_someSuffix");
            Assert.AreEqual(@"C:\Users\lydia\Desktop\puppy_someSuffix.jpg", testString);
        }

    }
}