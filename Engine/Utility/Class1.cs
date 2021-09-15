﻿using ATL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Engine.Utility
{
    public static class Class1
    {
        public static BitmapImage ExtractCoverFastRender(string filePath)
        {
            BitmapImage bitmap = null;

            if (filePath != null)
            {
                Track tagfile = new(filePath);
                if (tagfile.EmbeddedPictures.Count > 0)
                {
                    byte[] pic = tagfile.EmbeddedPictures[0]?.PictureData;
                    System.IO.MemoryStream ms = new(pic);
                    _ = ms.Seek(0, System.IO.SeekOrigin.Begin);

                    bitmap = new();
                    bitmap.BeginInit();

                    bitmap.StreamSource = ms;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.DecodePixelWidth = 10;
                    bitmap.DecodePixelHeight = 10;

                    bitmap.EndInit();
                    bitmap.Freeze();
                }
            }

            return bitmap;
        }
        public static BitmapImage ExtractCover(string filePath)
        {
            BitmapImage bitmap = null;

            if (filePath != null)
            {
                Track tagfile = new(filePath);
                if (tagfile.EmbeddedPictures.Count > 0)
                {
                    byte[] pic = tagfile.EmbeddedPictures[0]?.PictureData;
                    System.IO.MemoryStream ms = new(pic);
                    _ = ms.Seek(0, System.IO.SeekOrigin.Begin);

                    bitmap = new();
                    bitmap.BeginInit();

                    bitmap.StreamSource = ms;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;

                    bitmap.EndInit();
                    bitmap.Freeze();
                }
            }

            return bitmap;
        }

    }
}
