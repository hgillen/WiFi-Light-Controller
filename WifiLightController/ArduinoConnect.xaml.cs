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
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WifiLightController
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArduinoConnect : Page
    {
        public ArduinoConnect()
        {
            this.InitializeComponent();

            HostIp.Text = App.ipe.Address.MapToIPv4().ToString();
            HostPort.Text = App.ipe.Port.ToString();

            if (MainPage.isConnected)
            {
                ClientIp.Text = App.remoteEp.Address.ToString();
                ClientPort.Text = App.remoteEp.Port.ToString();

                ConnectButton.IsEnabled = false;
            }
        }

        private async void ConnectButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            // Broadcast "MARK" on udp

            // Set up the message
            string str1 = "MARK";
            byte[] msg = Encoding.ASCII.GetBytes(str1);

            // Send the message
            App.udpClient.Send(msg, msg.Length, App.ipe);

            await ReceiveUdp();

            ClientIp.Text = App.remoteEp.Address.ToString();
            ClientPort.Text = App.remoteEp.Port.ToString();
        }

        private async Task ReceiveUdp()
        {
            UdpReceiveResult udpReceiveResult = await App.udpClient.ReceiveAsync();
            App.remoteEp = udpReceiveResult.RemoteEndPoint;

            App.ipe.Address = App.homeAddress;
            HostIp.Text = App.ipe.Address.MapToIPv4().ToString();

            ConnectButton.IsEnabled = false;
            MainPage.isConnected = true;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WifiLightController.MainPage));
        }

        private void CircleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WifiLightController.ColorCircle));
        }

        private void LevelsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WifiLightController.ColorLevels));
        }
    }
}
