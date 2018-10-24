using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace server_udp
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpServer = new UdpClient(99);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, 99);
            while (true)
            {
                var remoteEP = new IPEndPoint(IPAddress.Any, 99);
                var data = udpServer.Receive(ref remoteEP); // listen on port 11000
                string str1 = System.Text.ASCIIEncoding.ASCII.GetString(data);
                Console.Write("receive data from " + remoteEP.ToString());
                udpServer.Send(new byte[] { 1 }, 1, remoteEP); // reply back
            }
        }
    }
}
