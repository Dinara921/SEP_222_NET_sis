using System.Net;
using System.Text;

namespace HTTP_Server_HW
{
    internal class Program
    {
        static Thread threawdListener;
        static void Main(string[] args)
        {
            threawdListener = new Thread(new ParameterizedThreadStart(Start));
            threawdListener.Start("http://localhost:12345/");
            threawdListener = new Thread(new ParameterizedThreadStart(Start2));
            threawdListener.Start("http://localhost:12346/");
        }
        public static void Start(object prefix)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(prefix.ToString());
            listener.Start();
            while (true)
            {
                Console.WriteLine("Прослушка работает ....");
                HttpListenerContext context = listener.GetContext();

                HttpListenerRequest request = context.Request;
                var qry = request.RawUrl.Split('/');
                string Segment1 = null;

                Segment1 = qry[1];

                int a;
                a = int.Parse(Segment1);


                Console.WriteLine("Получено .." + Segment1 + " ");
                HttpListenerResponse response = context.Response;


                string responseString = "<HTML><BODY> " + Factorial(a) + " </HTML></BODY>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);

                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                output.Close();
            }
        }

        public static void Start2(object prefix)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(prefix.ToString());
            listener.Start();
            while (true)
            {
                Console.WriteLine("Прослушка работает..");
                HttpListenerContext context = listener.GetContext();

                HttpListenerRequest request = context.Request;
                string text;
                int a;
                using (var reader = new StreamReader(request.InputStream,
                                                     request.ContentEncoding))
                {
                    text = reader.ReadToEnd();
                    string[] amp = text.Split('&');
                    string[] perem1 = amp[0].Split('=');
                    a = int.Parse(perem1[1]);
                }
                HttpListenerResponse response = context.Response;
                string responseString = "<HTML><BODY> Factorial = " + Factorial(a) + " </BODY></HTML>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);

                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                output.Close();
            }
        }

        static long Factorial(int n)
        {
            if (n < 0) return -1;
            if (n == 0) return 1;
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
