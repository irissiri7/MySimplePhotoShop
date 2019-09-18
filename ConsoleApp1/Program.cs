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
            Console.WriteLine("HEJDÅ");
            try
            {
                PhotoShopLib.ImageEditor.MakeBlurr(args[0]);
                PhotoShopLib.ImageEditor.MakeNegative(args[0]);
                PhotoShopLib.ImageEditor.MakeBlackAndWhite(args[0]);
                Console.WriteLine("Operations done. Copies of you manipulated images are saved where the original file is. Bye!");
                System.Environment.Exit(0);
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Something was wrong with the input. Please try to enter a new file path");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Something was wrong with the input. Please try to enter a new file path");
            }

            string input = Console.ReadLine();

            bool isInputValid = PhotoShopLib.InputHandler.CheckIfValidInput(input, out string message);

            if (isInputValid == false)
            {
                Console.WriteLine(message);
                Console.WriteLine("Program will exit");
                System.Environment.Exit(0);
            }

            else
            {
                PhotoShopLib.ImageEditor.MakeBlurr(input);
                PhotoShopLib.ImageEditor.MakeNegative(input);
                PhotoShopLib.ImageEditor.MakeBlackAndWhite(input);
                Console.WriteLine("Operations done. Copies of you manipulated images are saved where the original file is. Bye!");
                System.Environment.Exit(0);
            }

            

        }
    }
}
