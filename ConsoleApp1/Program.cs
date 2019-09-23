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
                "of your image and save it on your computer. We will now try to process " +
                "the image you have reffered to.");

            string filePath;

            if (args.Length > 0)
            {
                filePath = args[0];

                if (InputHandler.CheckIfValidInput(filePath, out string message1))
                {
                    try
                    {
                        Bitmap originalImage = new Bitmap(filePath);

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
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Oh, something was wrong with the input. Please try to enter a new file path");
                    }
                }
                else
                {
                    Console.WriteLine(message1);
                    Console.WriteLine("Please try to enter a new file path");
                }
            }
            else
            {
                Console.WriteLine("Could not find a file path. Please try to enter a new file path");
            }

            //Round 2: using new input from user, checking if valid and converting to Bitmap

            filePath = Console.ReadLine();

            bool isInputValid = InputHandler.CheckIfValidInput(filePath, out string message2);

            if (isInputValid == false)
            {
                Console.WriteLine(message2);
                Console.WriteLine("Program will exit");
                System.Environment.Exit(0);
            }

            else
            {
                Bitmap newOriginalImage = new Bitmap(filePath);

                Bitmap negativeImage = ImageEditor.MakeNegative(newOriginalImage, filePath, out string newPathNegative);
                negativeImage.Save(newPathNegative);

                Bitmap blackAndWhiteImage = ImageEditor.MakeBlackAndWhite(newOriginalImage, filePath, out string newPathBlackAndWhite);
                blackAndWhiteImage.Save(newPathBlackAndWhite);

                Bitmap blurredImage = ImageEditor.MakeBlur(newOriginalImage, filePath, out string newPathBlurred);
                blurredImage.Save(newPathBlurred);

                Console.WriteLine("Manipulations done!");
                Console.WriteLine("Copies of your manipulated images are saved where the original file is.");
                Console.WriteLine("Bye!");
                System.Environment.Exit(0);
            }

        }
    }
}
