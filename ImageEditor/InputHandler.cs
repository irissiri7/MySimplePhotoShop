using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PhotoShopLib
{
    public class InputHandler
    {
        public static bool CheckIfValidInput(string input, out string message)
        {
            bool validInput = true;
            message = "All clear";

            if (!File.Exists(input))
            {
                validInput = false;
                message = "The image dosen't exist!";
                return validInput;
            }

            if ((Path.GetExtension(input) != ".jpg") && (Path.GetExtension(input) != ".png") && (Path.GetExtension(input) != ".bmp") && (Path.GetExtension(input) != ".gif"))
            {
                validInput = false;
                message = "The image is not of right format";
                return validInput;
            }

            System.Drawing.Image img = System.Drawing.Image.FromFile(input);
            if (img.Height > 1300 || img.Width > 1300)
            {
                validInput = false;
                message = "The image is too big";
                return validInput;
            }
            if(img.Height < 300 || img.Width < 300)
            {
                validInput = false;
                message = "The image is too small";
                return validInput;
            }

            return validInput;

        }
    }
}
