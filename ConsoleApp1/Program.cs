using System;
using System.Drawing;
using System.Drawing.Imaging;
using PhotoShopLib;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to this fantastically sophisticated photoshop! " +
                "We will produce a negative, a black and white AND a blurred version " +
                "of your image and save it to your computer. We will now try to process " +
                "the image you have reffered to.");

            string filePath;
            Bitmap originalImage = new Bitmap(3, 3);

            //Round 1, attempting to use command prompt args.
            if (args.Length > 0)
            {
                filePath = args[0];
            }
            else
            {
                Console.WriteLine("Could not find a file path. Please enter a new file path");
                filePath = Console.ReadLine();
            }

            if (InputHandler.CheckIfValidInput(filePath, out string message1))
            {
                try
                {
                    originalImage = new Bitmap(filePath);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Something went wrong. Please try to enter a new file path");
                }
                Bitmap negativeImage = ImageEditor.MakeNegative(originalImage, filePath, out string newPathNegative);
                negativeImage.Save(newPathNegative);

                Bitmap blackAndWhiteImage = ImageEditor.MakeBlackAndWhite(originalImage, filePath, out string newPathBlackAndWhite);
                blackAndWhiteImage.Save(newPathBlackAndWhite);

                Bitmap blurredImage = ImageEditor.MakeBlur(originalImage, filePath, out string newPathBlurred);
                blurredImage.Save(newPathBlurred);

                Console.WriteLine("Manipulations done!");
                Console.WriteLine("Copies of your manipulated images are saved where the original file is.");
                Console.WriteLine("Bye!");
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine(message1);
                Console.WriteLine("Please try to enter a new file path");
            }

            filePath = Console.ReadLine();

            if (InputHandler.CheckIfValidInput(filePath, out string message2))
            {
                try
                {
                    originalImage = new Bitmap(filePath);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Something went wrong. Program will exit");
                    System.Environment.Exit(0);
                }

                Bitmap negativeImage = ImageEditor.MakeNegative(originalImage, filePath, out string newPathNegative);
                negativeImage.Save(newPathNegative);

                Bitmap blackAndWhiteImage = ImageEditor.MakeBlackAndWhite(originalImage, filePath, out string newPathBlackAndWhite);
                blackAndWhiteImage.Save(newPathBlackAndWhite);

                Bitmap blurredImage = ImageEditor.MakeBlur(originalImage, filePath, out string newPathBlurred);
                blurredImage.Save(newPathBlurred);

                Console.WriteLine("Manipulations done!");
                Console.WriteLine("Copies of your manipulated images are saved where the original file is.");
                Console.WriteLine("Bye!");
                System.Environment.Exit(0);    
            }
            else
            {
                Console.WriteLine(message2);
                Console.WriteLine("Program will exit");
                System.Environment.Exit(0);
            }
        }
    }
}
