﻿using AudioPlayer;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;

namespace MusicApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //[DllImport("Kernel32")]
        //private static extern void AllocConsole();

        internal static Player Player = new();

        protected override async void OnStartup(StartupEventArgs e)
        {
            //AllocConsole();
            Debug.WriteLine($"AppOnStartUp-args:[{ e.Args}]");
            base.OnStartup(e);
            try
            {
                string value = File.ReadAllText(@"Setting\IsDark");
                bool isdark = bool.Parse(value);

                if (isdark)
                {
                    Theme.WindowTheme.IsDark = true;
                    await Task.Run(() => Theme.ResourceManager.LoadThemeResourceDark());
                }
                else
                {
                    Theme.WindowTheme.IsDark = false;
                    await Task.Run(() => Theme.ResourceManager.LoadThemeResourceLight());
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            MainWindow.Show();
            MainWindow.Content = View.AllViews.MainView;

            await Task.Run(async () =>
            {
                if (e.Args?.Length > 0)
                {
                    _ = Task.Run(async () => await Player.Playlist.AddRangeAsync(e.Args));
                    Player.Source = e.Args[0];
                    await Player.OpenAsync();
                }
            });

        }
    }
}
