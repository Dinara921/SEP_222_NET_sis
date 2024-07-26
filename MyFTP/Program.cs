using FluentFTP;
using Renci.SshNet;
using System.Net;
using System.Net.Mail;

namespace MyFTP
{
    internal class Program
    {
        //https://filezilla.ru/download/FileZillaPortable_3.63.2.paf.exe
        static string url = "ftp://ftp.dlptest.com/";
        static string user = "dlpuser";
        static string password = "rNrKYTX9g7z3RgJRmxWuGHbeu";

        static void FTP_test()
        {
            FtpClient client = new FtpClient();
            client.Host = url;
            client.Credentials = new NetworkCredential(user, password);
            client.Connect();
            var status = client.UploadFile("123.txt", "/07/19/123kdadkadakdaskdjasklj.txt");
            ;
        }

        static void SFTP()
        {
            string Host = "test.rebex.net";
            int Port = 22;
            string LocalDestinationFilename = "123.txt";
            string Username = "demo";
            string Password = "password";

            using (var sftp = new SftpClient(Host, Port, Username, Password))
            {
                sftp.Connect();

                var files = sftp.ListDirectory("//");

                foreach (var file in files)
                {
                    Console.WriteLine(file.Name);
                }
                sftp.Disconnect();
            }
        }

        static void Main(string[] args)
        {
            //FTP_test();
            SFTP();
        }
       
    }
}