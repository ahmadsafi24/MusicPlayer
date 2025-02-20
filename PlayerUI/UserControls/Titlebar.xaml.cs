﻿using Helper.ViewModelBase;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PlayerUI.UserControls
{
    public partial class Titlebar : UserControl
    {
        public Titlebar()
        {
            InitializeComponent();
            Loaded += Titlebar_Loaded;
        }

        private void Titlebar_Loaded(object sender, RoutedEventArgs e)
        {
            TitlebarViewModel viewModel = new();
            viewModel.Window = Window.GetWindow(this);
            DataContext = viewModel;
        }

        public string CaptionString
        {
            get => GetValue(CaptionStringProperty) as string;
            set => SetValue(CaptionStringProperty, value);
        }
        public static readonly DependencyProperty CaptionStringProperty = DependencyProperty.Register(
          "CaptionString", typeof(string), typeof(Titlebar), new PropertyMetadata("App Title"));
    }

    public class TitlebarViewModel : ViewModelBase
    {
        public Window Window { get; set; }
        public ICommand CloseCommand { get; }
        public ICommand MaximizeRestoreCommand { get; }
        public ICommand MinimizeCommand { get; }
        public ICommand DragMoveCommand { get; }
        public ICommand ContextMenuCommand { get; }

        public TitlebarViewModel()
        {
            CloseCommand = new DelegateCommand(() => Helper.WindowsManager.CloseWindow(Window));
            MaximizeRestoreCommand = new DelegateCommand(() => Helper.WindowsManager.MaximizeRestore(Window));
            MinimizeCommand = new DelegateCommand(() => Helper.WindowsManager.Minimize(Window));
            DragMoveCommand = new DelegateCommand(() => Helper.WindowsManager.DragMove(Window));
            ContextMenuCommand = new DelegateCommand(() => Helper.WindowsManager.ShowContextMenu(Window));
        }
    }
}
