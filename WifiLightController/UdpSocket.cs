using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace WifiLightController
{
    class UdpSocket
    {
        Socket sendSock;
        static int hostPort = 12000, clientPort = 11000;


        //async Task StartConnect()
        //{
        //    //IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync(Dns.GetHostName());
        //    //IPAddress ipAddress = ipHostInfo.AddressList[0]; //ipHostInfo.AddressList[0];
        //    //IPEndPoint remoteEP = new IPEndPoint(ipAddress, portNo);

        //    //// Create a TCP/IP  socket.  
        //    //Socket sender = new Socket(ipAddress.AddressFamily,
        //    //    SocketType.Dgram, ProtocolType.Udp);

        //    //IPEndPoint senderEndP = new IPEndPoint(IPAddress.Broadcast, hostPort);

        //}

        //public static void ButtonClick()
        //{
        //    // Broadcast "MARK" on udp
            
        //    // Set up the message
        //    string str1 = "MARK";
        //    byte[] msg = Encoding.ASCII.GetBytes(str1);

        //    // Send the message
        //    udpc.Send(msg, msg.Length, ipe);

        //}




    }
}
