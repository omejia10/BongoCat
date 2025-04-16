using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using BongoCat.ViewModels;

namespace BongoCat.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            Topmost = true;
#if DEBUG
            this.AttachDevTools();
#endif
        }

        protected override void OnOpened(EventArgs e)
        {
            base.OnOpened(e);
            PixelSize screenSize = Screens.Primary.WorkingArea.Size;
            PixelSize windowSize = PixelSize.FromSize(ClientSize, Screens.Primary.Scaling);

            Position = new PixelPoint(
              screenSize.Width - windowSize.Width,
              screenSize.Height - windowSize.Height);
        }
    }

}