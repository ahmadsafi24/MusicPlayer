﻿using Helper.DarkUi;
using System;
using System.Windows;

namespace PlayerUI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow_Chromeless.xaml
    /// </summary>
    public partial class MainWindowChromeless : Window
    {
        public MainWindowChromeless()
        {
            InitializeComponent();
            MouseLeftButtonDown += (_, _) =>
            {
                if (this.WindowState != WindowState.Maximized)
                {
                    Helper.WindowsManager.DragMove(this);
                }
            };

            Commands.WindowTheme.ThemeChanged += WindowTheme_ThemeChanged;
            Commands.Window.AttachDrop(this);
            Commands.Window.AttachMouseWheel(this);
        }

        private void WindowTheme_ThemeChanged(bool isdark)
        {
            if (this.IsLoaded)
            {
                DwmApi.ToggleImmersiveDarkMode(this, isdark);
                UpdateLayout();
            }
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            Helper.WindowsManager.EnableBlur(this);
            Helper.IconHelper.RemoveIcon(this);
            Helper.ControlboxHelper.RemoveControls(this);
            DwmApi.ToggleImmersiveDarkMode(this, Commands.WindowTheme.IsDark);
        }
    }
}
