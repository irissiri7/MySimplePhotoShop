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
            string originalpath = "dummyPath";

            //Creating two identical images for testing
            Bitmap testImageManual = new Bitmap(3, 3);
            Bitmap testImageToMethod = new Bitmap(3, 3);

            Color startColor = Color.FromArgb(100, 100, 100);

            testImageManual.SetPixel(1, 1, startColor);
            testImageToMethod.SetPixel(1, 1, startColor);

            //Manually calculating the rgb-values for a negativ manipulation of the startColors 
            //and assiging it to new Color object.
            var negativeR = 255 - 100;
            var negativeG = 255 - 100;
            var negativeB = 255 - 100;

            Color manipulatedColors = Color.FromArgb(negativeR, negativeG, negativeB);

            //Assigning the manually manipulated pixels to testImageManual.
            testImageManual.SetPixel(1, 1, manipulatedColors);

            //Sending in the other test image to method for manipulation.
            Bitmap manipulatedBitmap = ImageEditor.MakeNegative(testImageToMethod, originalpath, out _);

            //Finally comparing the manually manipulated pixel with the pixel going through the method
            Assert.AreEqual(testImageManual.GetPixel(1, 1), manipulatedBitmap.GetPixel(1, 1));

        }

        [Test]
        public void ImageEditor_MakeBlackAndWhite_IsBlackAndWhite()
        {
            string originalpath = "dummyPath";

            //Creating two identical images for testing
            Bitmap testImageManual = new Bitmap(3, 3);
            Bitmap testImageToMethod = new Bitmap(3, 3);

            Color startColor = Color.FromArgb(70, 130, 200);

            testImageManual.SetPixel(1, 1, startColor);
            testImageToMethod.SetPixel(1, 1, startColor);

            //Manually calculating the rgb-values for a B&W manipulation of the startColors 
            //and assiging it to new Color object.
            var averageColors = (70 + 130 + 200) / 3;
            

            Color manipulatedColors = Color.FromArgb(averageColors, averageColors, averageColors);

            //Assigning the manually manipulated pixels to testImageManual.
            testImageManual.SetPixel(1, 1, manipulatedColors);

            //Sending in the other test image to method for manipulation.
            Bitmap manipulatedBitmap = ImageEditor.MakeBlackAndWhite(testImageToMethod, originalpath, out _);

            //Finally comparing the manually manipulated pixel with the pixel going through the method
            Assert.AreEqual(testImageManual.GetPixel(1, 1), manipulatedBitmap.GetPixel(1, 1));

        }

        [Test]
        public void ImageEditor_MakeBlurr_IsBlurr()
        {
            string originalpath = "dummyPath";

            //Creating two identical images for testing
            Bitmap testImageManual = new Bitmap(3, 3);
            Bitmap testImageToMethod = new Bitmap(3, 3);

            Color startColorBase = Color.FromArgb(100, 100, 100);
            Color startColorDeviantPixel = Color.FromArgb(200, 200, 200);

            //Setting up my testimages with a base color and one deviant pixel in the middle.
            SetAllPixels(testImageManual, startColorBase);
            SetAllPixels(testImageToMethod, startColorBase);
            testImageManual.SetPixel(1, 1, startColorDeviantPixel);
            testImageToMethod.SetPixel(1, 1, startColorDeviantPixel);


            //Manually calculating the rgb-values for a blurr manipulation of the startColors 
            //and assiging it to new Color object.
            var averageColorsR = ((100 * 8) + 200) / 9;
            var averageColorsG = ((100 * 8) + 200) / 9;
            var averageColorsB = ((100 * 8) + 200) / 9;


            Color manipulatedColors = Color.FromArgb(averageColorsR, averageColorsG, averageColorsB);

            //Assigning the manually manipulated pixels to testImageManual.
            testImageManual.SetPixel(1, 1, manipulatedColors);

            //Sending in the other test image to method for manipulation.
            Bitmap manipulatedBitmap = ImageEditor.MakeBlurr(testImageToMethod, originalpath, out _);

            //Finally comparing the manually manipulated pixel with the pixel going through the method
            Assert.AreEqual(testImageManual.GetPixel(1, 1), manipulatedBitmap.GetPixel(1, 1));

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
            bool resultOfSmallImage = InputHandler.CheckIfValidInput(testImage, out string message);
            Assert.AreEqual(false, resultOfSmallImage);
        }

        [Test]
        public void CheckInput_WrongFormat_ReturnsFalse()
        {
            string testImage = @"testImages\WrongFormat.gif";
            bool resultOfWrongFormat = InputHandler.CheckIfValidInput(testImage, out string message);
            Assert.AreEqual(true, resultOfWrongFormat);
        }

        //TESTING THE FILENAMEEDITOR
        [Test]
        public void FileNameEditor_HappyDays_ReturnsString()
        {
            string testImage = @"C:\Users\lydia\Desktop\puppy.jpg";
            string testString = PhotoShopLib.FileNameEditor.AddSuffixToFileName(testImage, "_someSuffix");
            Assert.AreEqual(@"C:\Users\lydia\Desktop\puppy_someSuffix.jpg", testString);
        }

        public static void SetAllPixels(Bitmap someBitmap, Color someColor)
        {
            int x, y;

            for (x = 0; x < someBitmap.Width; x++)
            {
                for (y = 0; y < someBitmap.Height; y++)
                {
                    someBitmap.SetPixel(x, y, someColor);
                }
            }
        }

    }
}