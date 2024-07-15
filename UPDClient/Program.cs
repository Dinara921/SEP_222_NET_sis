using System.Net.Sockets;
using System.Net;
using System.Text;

namespace UPDClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UDP.Send();
        }
        class UDP
        {
            public static void Send()
            {
                UdpClient Client = new UdpClient();
                var data = Encoding.UTF8.GetBytes("hello step");
                Client.Send(data, data.Length, GetLocalIPAddress(), 8001);
            }

            public static string GetLocalIPAddress()
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                return null;
            }
        }
    }
}
