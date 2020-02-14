using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WifiLightController
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ColorCircle : Page
    {

        public ColorCircle()
        {
            this.InitializeComponent();

            App.newColor.A = 255;
            BackGrid.Background = new SolidColorBrush(App.newColor);
        }

        private void ColorWheel_ColorChanged(ColorPicker sender, ColorChangedEventArgs args)
        {
            App.levelR = App.newColor.R = sender.Color.R;
            App.levelG = App.newColor.G = sender.Color.G;
            App.levelB = App.newColor.B = sender.Color.B;

            App.ChangeColor();

            BackGrid.Background = new SolidColorBrush(App.newColor);
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WifiLightController.ArduinoConnect));
        }

        private void LevelsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WifiLightController.ColorLevels));
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WifiLightController.MainPage));
        }
    }
}
