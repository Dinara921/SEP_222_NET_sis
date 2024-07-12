using System.Net;
using System.Net.Sockets;

namespace UDPServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(UDP.GetLocalIPAddress());
        }
    }

    class UDP
    {
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