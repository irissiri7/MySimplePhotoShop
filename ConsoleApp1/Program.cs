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
            //First round: attemting to use command prompt args.
            try
            {
                Bitmap negativeImage = ImageEditor.MakeNegative(args[0], out string newFilePathNegative);
                negativeImage.Save(newFilePathNegative);

                Bitmap blackAndWhiteImage = ImageEditor.MakeBlackAndWhite(args[0], out string newFilePathBlackAndWhite);
                blackAndWhiteImage.Save(newFilePathBlackAndWhite);
                
                Bitmap blurredImage = ImageEditor.MakeBlurr(args[0], out string newFilePathBlurred);
                blurredImage.Save(newFilePathBlurred);

                Console.WriteLine("Operations done. Copies of you manipulated images are saved where the original file is. Bye!");
                System.Environment.Exit(0);
            }

            //If command promt args not available, asking for new input
            catch (ArgumentException)
            {
                Console.WriteLine("Something was wrong with the input. Please try to enter a new file path");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Something was wrong with the input. Please try to enter a new file path");
            }

            //Round 2: using new input
            string input = Console.ReadLine();

            bool isInputValid = InputHandler.CheckIfValidInput(input, out string message);

            if (isInputValid == false)
            {
                Console.WriteLine(message);
                Console.WriteLine("Program will exit");
                System.Environment.Exit(0);
            }

            else
            {
                Bitmap blurredImage = ImageEditor.MakeBlurr(input, out string filePathBlurr);
                blurredImage.Save(filePathBlurr);

                Bitmap NegativeImage = ImageEditor.MakeNegative(input, out string filePathNegative);
                blurredImage.Save(filePathNegative);


                Bitmap BlackAndWhiteImage = ImageEditor.MakeBlackAndWhite(input, out string filePathBlackAndWhite);
                blurredImage.Save(filePathBlackAndWhite);

                Console.WriteLine("Operations done. Copies of you manipulated images are saved where the original file is. Bye!");
                System.Environment.Exit(0);
            }

            

        }
    }
}
