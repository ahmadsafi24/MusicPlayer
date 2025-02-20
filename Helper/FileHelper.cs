﻿using System.Windows.Media.Imaging;

namespace Helper
{
    public static class FileHelper
    {
        public static void SaveBitmapImageToPng(BitmapImage image, string destinationFilePath)
        {
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using System.IO.FileStream filestream = new(destinationFilePath, System.IO.FileMode.Create);
            encoder.Save(filestream);
        }

        public static void OpenFileWithDefaultApp(string filepath)
        {
            if (System.IO.File.Exists(filepath))
            {
                System.Diagnostics.Process start = new()
                {
                    StartInfo = new(filepath)
                    {
                        CreateNoWindow = true,
                        UseShellExecute = true,
                    }
                };
                start.Start();
            }
        }
    }
}
