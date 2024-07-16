using HtmlAgilityPack;
using System.Net;

namespace HTTP_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Method_4();  
        }

        static async Task<string> Method_1()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetStringAsync("https://www.google.com/");
                return result;
            }
        }
        static async Task Method_2()
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetAsync("https://www.google.com/");

                //var result = response.Content.ReadAsStringAsync().Result;
                using (StreamReader sr = new StreamReader(await result.Content.ReadAsStreamAsync()))
                {
                    string result2 = sr.ReadToEnd();
                    Console.WriteLine(result2);
                }

            }
        }

        static void Method_3()
        {
            using (var client = new WebClient())
            {
                //var result = client.DownloadData("https://www.nationalbank.kz/file/download/101938");
                //File.WriteAllBytes("c:\\temp\\123.pdf", result);

                //var result = client.DownloadData("https://www.nationalbank.kz/file/download/102469");
                //File.WriteAllBytes("c:\\temp\\123.xlsx", result);

                var result = client.DownloadData("https://sefon.pro/mp3/1468282-jazzdauren-pesni-na-kassete/");
                File.WriteAllBytes("c:\\temp\\123.mp3", result);

            }
        }

        static void Method_4()
        {
            DateTime dt = DateTime.Now;
            var html = @"https://www.nationalbank.kz/ru/exchangerates/ezhednevnye-oficialnye-rynochnye-kursy-valyut";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[1]/main/section/div/div/div[2]/div/form/div[2]/table/tbody");
            HtmlNodeCollection childNodes = htmlBody.ChildNodes;
            var names = new List<string>() { "1 ДОЛЛАР США", "1 ЕВРО", "1 РОССИЙСКИЙ РУБЛЬ", "1 ФУНТ СТЕРЛИНГОВ СОЕДИНЕННОГО КОРОЛЕВСТВА" };
            var exchangeRates = new Dictionary<string, string>
            {
                { "1 ДОЛЛАР США", "" },
                { "1 ЕВРО", "" },
                { "1 РОССИЙСКИЙ РУБЛЬ", "" },
                { "1 ФУНТ СТЕРЛИНГОВ СОЕДИНЕННОГО КОРОЛЕВСТВА", "" }
            };
            foreach (var node in childNodes)
            {
                if (node.InnerHtml == "\n                            " || node.InnerHtml == "\n                        ")
                    continue;
                var inNode = node.InnerHtml;
                var valute = inNode.Split("td")[3].Split(">")[1].Split("<")[0];
                var tg = inNode.Split("td")[7].Split(">")[1].Split("<")[0];
                if (exchangeRates.ContainsKey(valute))
                {
                    exchangeRates[valute] = tg;
                }
            }
            Console.WriteLine($"Дата: {dt.ToShortDateString()}");
            Console.WriteLine($"1 USD - {exchangeRates["1 ДОЛЛАР США"]} ТЕНГЕ");
            Console.WriteLine($"1 EUR - {exchangeRates["1 ЕВРО"]} ТЕНГЕ");
            Console.WriteLine($"1 RUB - {exchangeRates["1 РОССИЙСКИЙ РУБЛЬ"]} ТЕНГЕ");
            Console.WriteLine($"1 GBP - {exchangeRates["1 ФУНТ СТЕРЛИНГОВ СОЕДИНЕННОГО КОРОЛЕВСТВА"]} ТЕНГЕ");
        }
    }
}
