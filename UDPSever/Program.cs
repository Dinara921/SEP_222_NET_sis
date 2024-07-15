using System.Net.Sockets;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO.Compression;

namespace UDPServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UDP.Listen();
        }
    }
    class UDP
    {
        public static void Listen()
        {
            int PORT = 8001;
            UdpClient udpClient = new UdpClient(PORT);
            Console.WriteLine("Server is listening on port " + PORT);

            while (true)
            {
                IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, PORT);
                byte[] receivedBytes = udpClient.Receive(ref clientEndPoint);
                string receivedData = Encoding.UTF8.GetString(receivedBytes);

                if (receivedData.StartsWith("FILE:"))
                {
                    string fileName = receivedData.Substring(5);
                    ReceiveFile(udpClient, clientEndPoint, fileName);
                }
                else
                {
                    Console.WriteLine("Received unexpected data: " + receivedData);
                }
            }
        }

        private static void ReceiveFile(UdpClient client, IPEndPoint clientEndPoint, string fileName)
        {
            Console.WriteLine("Receiving file: " + fileName);

            try
            {
                byte[] fileBytes = client.Receive(ref clientEndPoint);
                File.WriteAllBytes(fileName, fileBytes);

                Console.WriteLine("File received and saved: " + fileName);

                string zipFileName = Path.ChangeExtension(fileName, ".zip");
                ZipFile.CreateFromDirectory(Path.GetDirectoryName(fileName), zipFileName);

                Console.WriteLine("File archived as: " + zipFileName);

                byte[] responseBytes = Encoding.UTF8.GetBytes("File archived as: " + zipFileName);
                client.Send(responseBytes, responseBytes.Length, clientEndPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error receiving file: " + ex.Message);
            }
        }
    }
}