﻿using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendToServer();       
        }

        async Task SendToServer()
        {
            await Task.Run(() =>
            {
                byte[] bytes = new byte[1024];
                var ip = Dns.GetHostEntry(tbHost.Text);
                var ad = ip.AddressList[0];
                var ep = new IPEndPoint(ad, int.Parse(tbPort.Text));
                Socket sender = new Socket(ad.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(ep); 
                byte[] msg = Encoding.UTF8.GetBytes(tbMessage.Text);
                int count = sender.Send(msg);
                count = sender.Receive(bytes);
                listBox1.Items.Add("Ответ от сервера " + Encoding.UTF8.GetString(bytes, 0, count));
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            });
        }

        async Task SendToServerToFile()
        {
            await Task.Run(() =>
            {
                byte[] bytes = new byte[1024];
                var ip = Dns.GetHostEntry(tbHost.Text);
                var ad = ip.AddressList[0];
                var ep = new IPEndPoint(ad, int.Parse(tbPort.Text));
                Socket sender = new Socket(ad.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(ep);
                string filePath = @"C:\Users\ЖиенбаеваД\Desktop\info.txt.txt";
                byte[] msg = System.IO.File.ReadAllBytes(filePath);

                //byte[] msg = Encoding.UTF8.GetBytes(tbMessage.Text);
                using (var writer = File.AppendText(filePath))
                {
                    var line = "Hello World!";
                    writer.WriteLine(line);
                }
                int count = sender.Send(msg);
                count = sender.Receive(bytes);
                listBox1.Items.Add("Ответ от сервера " + Encoding.UTF8.GetString(bytes, 0, count));
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            });
        }

        async Task SendToServer2()
        {
            await Task.Run(() =>
            {
                TcpClient client = null;
                try
                {
                    string message = tbHost.Text;
                    client = new TcpClient("127.0.0.1", int.Parse(tbPort.Text) + 1);
                    NetworkStream stream = client.GetStream();

                    // îòïðàâëÿåì ñîîáùåíèå
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine(message);
                    writer.Flush();

                    // BinaryReader reader = new BinaryReader(new BufferedStream(stream));
                    StreamReader reader = new StreamReader(stream);
                    message = reader.ReadLine();
                    listBox1.Items.Add("Спасибо: " + message);

                    reader.Close();
                    writer.Close();
                    stream.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (client != null)
                        client.Close();
                }

            });

        }
        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void tbMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendToServerToFile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SendToServer2();
        }
    }
}