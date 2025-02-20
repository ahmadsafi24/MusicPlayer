﻿using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper
{
    public static class FileOpenPicker
    {
        public static string DialogTitle { get; set; }
        public static string PickerTitle { get; set; }

        public static bool IsFileOk { get; set; }
        public static List<FileDialogCustomPlace> CustomPlacelist { get; set; }

        public static async Task<string[]> GetFileAsync()
        {
            return await Task.Run(() =>
             {
                 OpenFileDialog openFileDialog = new()
                 {
                     Filter =
                     "All Supported Audio | *.mp3; *.wma |" +
                     "MP3 | *.mp3 |" +
                     "Wav | *.wav |" +
                     "WMA | *.wma",

                     AddExtension = true,
                     //DefaultExt = ".mp3",
                     Multiselect = true,
                     CheckFileExists = true,
                     CustomPlaces = CustomPlacelist,
                     InitialDirectory = "",
                     Title = PickerTitle

                 };
                 IsFileOk = (bool)openFileDialog.ShowDialog().HasValue;
                 return IsFileOk ? openFileDialog.FileNames : null;

             });
        }

        public static string[] GetFiles()
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter =
                     "All Supported Audio | *.mp3; *.wma |" +
                     "MP3 | *.mp3 |" +
                     "Wav | *.wav |" +
                     "WMA | *.wma",

                AddExtension = true,
                //DefaultExt = ".mp3",
                Multiselect = true,
                CheckFileExists = true,
                CustomPlaces = CustomPlacelist,
                InitialDirectory = "",
                Title = PickerTitle

            };
            IsFileOk = (bool)openFileDialog.ShowDialog().HasValue;
            return IsFileOk ? openFileDialog.FileNames : null;
        }
        public static string[] GetFiles(string fileExtention)
        {
            OpenFileDialog openFileDialog = new()
            {

                Filter = $"{fileExtention} | *.{fileExtention}",

                AddExtension = true,
                //DefaultExt = ".mp3",
                Multiselect = true,
                CheckFileExists = true,
                CustomPlaces = CustomPlacelist,
                InitialDirectory = "",
                Title = PickerTitle

            };
            openFileDialog.ShowDialog();
            if (openFileDialog.FileNames.Count() > 0)
            {
                return openFileDialog.FileNames;
            }
            else
            {
                return null;
            }
        }
    }
}
