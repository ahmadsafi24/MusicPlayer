﻿using Engine.Model;
using MusicApplication.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Helper.DarkUi;
using System.Windows;
using System.Windows.Interop;

namespace MusicApplication.ViewModel
{
    public class MenuViewModel : Base.ViewModelBase
    {
        public ICommand OpenCommand { get; }
        public ICommand TestCommand { get; }

        public MenuViewModel()
        {
            OpenCommand = new DelegateCommand(() => Shared.OpenFilePicker());
            TestCommand = new DelegateCommand(() => Test());
        }

        private static void Test()
        {
            if (WindowsManager.isDark)
            {
                _ = WindowsManager.SetPreferredAppMode(AppMode.ForceDark);
                ResourceDictionary Dark = new()
                {
                    Source = new Uri("..\\Resource\\Theme\\Dark.Xaml", UriKind.Relative)
                };
                Application.Current.Resources.MergedDictionaries[0] = Dark;
                DwmApi.ToggleImmersiveDarkMode(WindowsManager.mainWindow, true);
            }
            else
            {
                _ = WindowsManager.SetPreferredAppMode(AppMode.ForceLight);
                ResourceDictionary Light = new()
                {
                    Source = new Uri("..\\Resource\\Theme\\Light.Xaml", UriKind.Relative)
                };
                Application.Current.Resources.MergedDictionaries[0] = Light;
                DwmApi.ToggleImmersiveDarkMode(WindowsManager.mainWindow, false);
            }
            WindowsManager.isDark = !WindowsManager.isDark;
            
            WindowsManager.mainWindow.Hide();
            WindowsManager.mainWindow.Show();
            
            /* Playlist playlist = new Playlist();
             System.Windows.Window window = new();
             window.BeginInit();
             playlist.DataContext = new PlaylistViewModel();
             window.Content = playlist;
             playlist.InitializeComponent();
             window.EndInit();
             window.Show();*/
        }

        private static List<string> getAllFilesPaths(PlaylistFile playlist)
        {
            List<string> paths = new();
            foreach (AudioFile item in playlist.Items)
            {
                paths.Add(item.FilePath);
                Debug.WriteLine(item.FilePath);
            }
            return paths;
        }
    }
}
