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

            //Round 1: attemting to use command prompt args.
            
            try
            {
                if (InputHandler.CheckIfValidInput(args[0], out string message1) == true)
                { 
                    Bitmap originalImage = new Bitmap(args[0]);
                    ImageEditor.ManipulateAllAndCloseProgram(originalImage, args[0]);
                }
                else
                {
                    Console.WriteLine(message1);
                    Console.WriteLine("Please try to enter a new file path");
                }
            }

            //If command promt args doesn't work, asking for new input
            catch (ArgumentException)
            {
                Console.WriteLine("Oh, something was wrong with the input. Please try to enter a new file path");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Oh, something was wrong with the input. Please try to enter a new file path");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Oh, something was wrong with the input. Please try to enter a new file path");
            }

            //Round 2: using new input from user, checking if valid and converting to Bitmap
            string inputPath = Console.ReadLine();
            bool isInputValid = InputHandler.CheckIfValidInput(inputPath, out string message2);

            if (isInputValid == false)
            {
                Console.WriteLine(message2);
                Console.WriteLine("Program will exit");
                System.Environment.Exit(0);
            }

            else
            {
                Bitmap newOriginalImage = new Bitmap(inputPath);
                ImageEditor.ManipulateAllAndCloseProgram(newOriginalImage, inputPath);
            }

        }
    }
}
