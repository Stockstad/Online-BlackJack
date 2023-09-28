using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace BlackJack
{
    static class DataConnection
    {
        private static readonly Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private const int Port = 100;
        private static string UserIP = IPAddress.Loopback.ToString();
        private static AddressFamily family;




        public static void ConnectToServer()
        {
            if (!ClientSocket.Connected)
            {
                ClientSocket.Connect(UserIP, Port);
            }
        }

        public static void SendData(string data)
        {

            try
            {
                ClientSocket.Send(Encoding.UTF8.GetBytes(data), SocketFlags.None);
            }
            catch (Exception)
            {

            }

        }

        public static string GetData()
        {
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            return Encoding.UTF8.GetString(buffer, 0, received);

        }

     
       
    }
}
