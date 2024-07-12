using System.Net;
using System.Text;

namespace MyHTTP
{
    internal class Program
    {
        static Thread threawdListener;
        static void Main(string[] args)
        {
            #region
            //int lim = 225000;
            //int kredit = 68000;
            //int sumPr = 21000;
            //int res = 0;
            //for (int i = 1; i * sumPr <= lim - kredit; i++)
            //{
            //    res = i;
            //}
            //Console.WriteLine($"Вы сможете купить {res} товаров");
            #endregion

            threawdListener = new Thread(new ParameterizedThreadStart(Start2));
            threawdListener.Start("http://localhost:12345/");
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
                string Segment2 = null;
                string Segment3 = null;
                Segment1 = qry[1];
                Segment2 = qry[2];
                Segment3 = qry[3];

                double a, b, c;
                a = double.Parse(Segment1);
                b = double.Parse(Segment2);
                c = double.Parse(Segment3);

                Console.WriteLine("Получено .." + Segment1 + " " + Segment2 + " " + Segment3);
                HttpListenerResponse response = context.Response;


                string responseString = "<HTML><BODY> " + Root(a, b, c) + " </HTML></BODY>";
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
                double a, b, c;
                using (var reader = new StreamReader(request.InputStream,
                                                     request.ContentEncoding))
                {
                    text = reader.ReadToEnd();
                    string[] amp = text.Split('&');
                    string[] perem1 = amp[0].Split('=');
                    string[] perem2 = amp[1].Split('=');
                    string[] perem3 = amp[2].Split('=');
                    a = double.Parse(perem1[1]);
                    b = double.Parse(perem2[1]);
                    c = double.Parse(perem3[1]);
                }
                HttpListenerResponse response = context.Response;
                string responseString = "<HTML><BODY> HELLO " + Root(a, b, c) + " </BODY></HTML>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);

                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);

                output.Close();
            }
        }

        public static string Root(double a, double b, double c)
        {
            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return "<HTML><BODY> <ul>  Roots of quadratic equation " + "<li style = 'color:aqua'>" + $"ROOT 1: {root1}" + "<li style = 'color:aqua'>" + $"ROOT 2: {root2}" + "</ul></HTML></BODY>";
            }
            else if (discriminant == 0)
            {
                double root = -b / (2 * a);
                return $"ROOT: {root}";
            }
            else
            {
                return "NO ROOTS.";
            }
        }

    }
}