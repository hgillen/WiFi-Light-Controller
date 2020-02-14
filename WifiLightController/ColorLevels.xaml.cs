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
    public sealed partial class ColorLevels : Page
    {

        public ColorLevels()
        {
            this.InitializeComponent();
            App.newColor.A = 255;

            RedSlider.Value = App.newColor.R;
            GreenSlider.Value = App.newColor.G;
            BlueSlider.Value = App.newColor.B;

            BackGrid.Background = new SolidColorBrush(App.newColor);
        }

        private void RedSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            App.levelR = App.newColor.R = (byte)RedSlider.Value;
            SendColor();
        }

        private void GreenSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            App.levelG = App.newColor.G = (byte)GreenSlider.Value;
            SendColor();
        }

        private void BlueSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            App.levelB = App.newColor.B = (byte)BlueSlider.Value;
            SendColor();
        }

        private void SendColor()
        {
            BackGrid.Background = new SolidColorBrush(App.newColor);
            App.ChangeColor();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WifiLightController.ArduinoConnect));
        }

        private void CircleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WifiLightController.ColorCircle));
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WifiLightController.MainPage));
        }

    }
}
