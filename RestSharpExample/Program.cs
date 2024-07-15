using RestSharp;

namespace RestSharpExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Отправка GET запроса на http://localhost:12345/5
            TestGetFactorial(5);

            // Отправка POST запроса на http://localhost:12346/
            TestPostFactorial(5);
        }

        static void TestGetFactorial(int number)
        {
            var client = new RestClient("http://localhost:12345/");
            var request = new RestRequest($"{number}", Method.Get);
            var response = client.Execute(request);

            Console.WriteLine("GET Response:");
            Console.WriteLine(response.Content);
        }

        static void TestPostFactorial(int number)
        {
            var client = new RestClient("http://localhost:12346/");
            var request = new RestRequest("", Method.Post);
            request.AddParameter("a", number);
            var response = client.Execute(request);

            Console.WriteLine("POST Response:");
            Console.WriteLine(response.Content);
        }
    }
}
