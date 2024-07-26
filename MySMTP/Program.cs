using System.Net.Mail;

namespace MySMTP
{
    internal class Program
    {
        ////https://help.mail.ru/mail/mailer/popsmtp
        static void Main(string[] args)
        {
            MailSend.Send();
        }
        public class MailSend
        {
            public static void Send()
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.IsBodyHtml = true;
                    mail.From = new MailAddress("dinash6145@mail.ru");
                    mail.To.Add("murat_b@mail.ru");
                    mail.Subject = "SMTP";
                    mail.Body = "HelloStep";
                    using (System.Net.Mail.SmtpClient server = new System.Net.Mail.SmtpClient("smtp.mail.ru", 587))
                    {
                        server.UseDefaultCredentials = false;
                        server.Credentials = new System.Net.NetworkCredential("dinash6145@mail.ru", "apFLK2f2mLBXPgyunCnn");
                        server.EnableSsl = true;
                        server.DeliveryMethod = SmtpDeliveryMethod.Network;
                        server.Send(mail);
                        server.Dispose();
                        Console.WriteLine("Send");
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }
    }
}