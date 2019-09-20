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
            Console.WriteLine("Welcome to this awesome photoshop! We will shortly try to process the image you have reffered to.");
            
            //Round: attemting to use command prompt args.
            try
            {
                ImageEditor.ManipulateAllAndCloseProgram(args[0]);
            }

            //If command promt args not available, asking for new input
            catch (ArgumentException)
            {
                Console.WriteLine("Something was wrong with the input. Please try to enter a new file path");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Something was wrong with the input. Please try to enter a new file path");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Something was wrong with the input. Please try to enter a new file path");
            }

            //Round 2: using new input
            string originalFilePath = Console.ReadLine();

            bool isInputValid = InputHandler.CheckIfValidInput(originalFilePath, out string message);

            if (isInputValid == false)
            {
                Console.WriteLine(message);
                Console.WriteLine("Program will exit");
                System.Environment.Exit(0);
            }

            else
            {
                ImageEditor.ManipulateAllAndCloseProgram(originalFilePath);
            }

        }
    }
}
