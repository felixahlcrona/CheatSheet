using CloudflareSolverRe;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HtmlAgilityPack
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CrawlSite();
            Console.WriteLine("Hello World!");
        }


        public static async Task CrawlSite()
        {
            var htmlDoc = await ExecuteGetRequest($"https://subscene.com/");

            var subtitleUrls = htmlDoc.DocumentNode.SelectNodes("//*[@id='search']").FirstOrDefault().InnerText;
        }

        private static HttpClient getCustomHttpClient()
        {
            // Cloudflare Bypass DDOS captcha
            var handler = new ClearanceHandler
            {
                MaxTries = 3,
                ClearanceDelay = 3000
            };

            var client = new HttpClient(handler);
            return client;
        }


        public static async Task<HtmlDocument> ExecuteGetRequest(string url)
        {
            HttpClient client = getCustomHttpClient();
            var response = await client.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            HtmlDocument _htmlDoc = new HtmlDocument();
            _htmlDoc.LoadHtml(content);

            return _htmlDoc;
        }

    }
}
