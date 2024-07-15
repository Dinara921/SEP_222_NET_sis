using System.Net.Sockets;
using System.Net;
using System.Text;

namespace UPDClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\dinas\Desktop\1.txt"; 
            string serverIP = "localhost";
            int serverPort = 8001;

            UDP.SendFile(filePath, serverIP, serverPort);
        }
        class UDP
        {
            public static void SendFile(string filePath, string serverIP, int serverPort)
            {
                try
                {
                    using (UdpClient udpClient = new UdpClient())
                    {
                        string fileName = Path.GetFileName(filePath);
                        byte[] fileNameBytes = Encoding.UTF8.GetBytes("FILE:" + fileName);
                        udpClient.Send(fileNameBytes, fileNameBytes.Length, serverIP, serverPort);

                        byte[] fileBytes = File.ReadAllBytes(filePath);
                        udpClient.Send(fileBytes, fileBytes.Length, serverIP, serverPort);

                        Console.WriteLine("File sent: " + fileName);

                        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
                        byte[] responseBytes = udpClient.Receive(ref serverEndPoint);
                        string response = Encoding.UTF8.GetString(responseBytes);
                        Console.WriteLine("Server response: " + response);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending file: " + ex.Message);
                }
            }
        }
    }
}
