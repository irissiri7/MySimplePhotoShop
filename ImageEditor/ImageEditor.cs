using System;
using System.Drawing;
using System.IO;

namespace PhotoShopLib
{
    public class ImageEditor
    {

        public static Bitmap MakeNegative(Bitmap originalImage, string originalPath, out string newPath)
        {
            Bitmap imageClone = (Bitmap)originalImage.Clone();

            int x, y;

            for (x = 0; x < imageClone.Width; x++)
            {
                for (y = 0; y < imageClone.Height; y++)
                {
                    Color pixelColor = imageClone.GetPixel(x, y);

                    var negativeR = 255 - pixelColor.R;
                    var negativeG = 255 - pixelColor.G;
                    var negativeB = 255 - pixelColor.B;

                    Color newColor = Color.FromArgb(negativeR, negativeG, negativeB);
                    imageClone.SetPixel(x, y, newColor);
                }
            }

            newPath = FileNameEditor.AddSuffixToFileName(originalPath, "_negative");

            return imageClone;
        }

        public static Bitmap MakeBlackAndWhite(Bitmap originalImage, string originalPath, out string newPath)
        {
            Bitmap imageClone = (Bitmap)originalImage.Clone();

            int x, y;

            for (x = 0; x < imageClone.Width; x++)
            {
                for (y = 0; y < imageClone.Height; y++)
                {
                    Color pixelColor = imageClone.GetPixel(x, y);

                    var averageValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    Color newColor = Color.FromArgb(averageValue, averageValue, averageValue);
                    imageClone.SetPixel(x, y, newColor);
                }
            }

            newPath = FileNameEditor.AddSuffixToFileName(originalPath, "_blackandwhite");

            return imageClone;
        }

        ///This method will blur all pixels except the outer ones, meaning the image will have a "frame" 
        ///of 1 px wide unblurred pixels. For that reason the program doesnt accept images under 300x300px
        public static Bitmap MakeBlur(Bitmap originalImage, string originalPath, out string newPath)
        {
            Bitmap imageClone = (Bitmap)originalImage.Clone();

            int x, y;

            for (x = 1; x < imageClone.Width- 1; x++)
            {
                for (y = 1; y < imageClone.Height - 1; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);

                    Color colorPrevX = originalImage.GetPixel(x - 1, y);
                    Color colorNextX = originalImage.GetPixel(x + 1, y);
                    Color colorPrevY = originalImage.GetPixel(x, y - 1);
                    Color colorNextY = originalImage.GetPixel(x, y + 1);

                    Color colorCorner1 = originalImage.GetPixel(x - 1, y - 1);
                    Color colorCorner2 = originalImage.GetPixel(x + 1, y - 1);
                    Color colorCorner3 = originalImage.GetPixel(x- 1, y + 1);
                    Color colorCorner4 = originalImage.GetPixel(x + 1, y + 1);

                    var averageR = (originalColor.R + colorPrevX.R + colorNextX.R + colorPrevY.R + colorNextY.R + colorCorner1.R + colorCorner2.R + colorCorner3.R + colorCorner4.R) / 9;
                    var averageG = (originalColor.G + colorPrevX.G + colorNextX.G + colorPrevY.G + colorNextY.G + colorCorner1.G + colorCorner2.G + colorCorner3.G + colorCorner4.G) / 9;
                    var averageB = (originalColor.B + colorPrevX.B + colorNextX.B + colorPrevY.B + colorNextY.B + colorCorner1.B + colorCorner2.B + colorCorner3.B + colorCorner4.B) / 9;

                    Color newColor = Color.FromArgb(averageR, averageG, averageB);

                    imageClone.SetPixel(x, y, newColor);

                }
            }

            newPath = FileNameEditor.AddSuffixToFileName(originalPath, "_blur");

            return imageClone;
        }

        


    }
}