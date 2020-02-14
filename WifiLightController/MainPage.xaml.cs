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
using System.Net.Sockets;
using System.Net;
//using muxc = Microsoft.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WifiLightController
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //public static UdpClient udpClient;
        //public static IPEndPoint ipe, remoteEp;
        //public static IPAddress homeAddress;
        public static bool isConnected;

        //public static int levelR, levelG, levelB;

        //private static int recvPort = 12000, sendPort = 11000;

        public MainPage()
        {
            this.InitializeComponent();

            if (!isConnected)
            {
                CircleButton.Visibility = Visibility.Collapsed;
                LevelsButton.Visibility = Visibility.Collapsed;
            }

            //InitSocket();

        }

        private void CircleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WifiLightController.ColorCircle));
        }

        private void LevelsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WifiLightController.ColorLevels));
        }

        //private void NavView_ItemInvoked(muxc.NavigationView sender, muxc.NavigationViewSelectionChangedEventArgs args)
        //{
        //    if (args.IsSettingsInvoked == true)
        //    {
        //        NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
        //    }
        //    else if (args.InvokedItemContainer != null)
        //    {
        //        var navItemTag = args.InvokedItemContainer.Tag.ToString();
        //        NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
        //    }
        //}

        //private void NavView_Navigate(string navItemTag, NavigationTransitionInfo transitionInfo)
        //{
        //    Type _page = null;
        //    if (navItemTag == "settings")
        //    {
        //        _page = typeof(SettingsPage);
        //    }
        //    else
        //    {
        //        var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
        //        _page = item.Page;
        //    }
        //    // Get the page type before navigation so you can prevent duplicate
        //    // entries in the backstack.
        //    var preNavPageType = ContentFrame.CurrentSourcePageType;

        //    // Only navigate if the selected page isn't currently loaded.
        //    if (!(_page is null) && !Type.Equals(preNavPageType, _page))
        //    {
        //        ContentFrame.Navigate(_page, null, transitionInfo);
        //    }
        //}

        //public static void InitSocket()
        //{
        //    // Set up the socket
        //    IPHostEntry iphe = Dns.GetHostEntry(Dns.GetHostName());
        //    homeAddress = iphe.AddressList[3];

        //    //// Debugging: Write all addresses to console
        //    //for (int i = 0; i < iphe.AddressList.Length; ++i)
        //    //    Console.WriteLine("HOST {0} - Address {1}", Dns.GetHostName(), iphe.AddressList[i].MapToIPv4().ToString());

        //    ipe = new IPEndPoint(IPAddress.Parse("192.168.0.255"), sendPort);

        //    udpClient = new UdpClient(recvPort);

        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WifiLightController.ArduinoConnect));
        }

        //public static void ChangeColor()
        //{
        //    byte[] colorByte = { (byte)levelR, (byte)levelG, (byte)levelB };

        //    udpClient.Send(colorByte, 3, ipe);
        //}


    }
}
