using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PhotoShopLib
{
    public class FileNameEditor
    {
        public static string AddSuffixToFileName(string originalFilePath, string suffix)
        {
            string directory = Path.GetDirectoryName(originalFilePath);
            string fileName = Path.GetFileNameWithoutExtension(originalFilePath);
            string extension = Path.GetExtension(originalFilePath);

            string newPath = Path.Combine(directory, String.Concat(fileName, suffix, extension));

            return newPath;
        }
    }
}
