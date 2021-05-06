using RestSharp;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace CheatSheet
{
    public class HttpExamples
    {

        public static async Task HttpClientGetGoogleImages()
        {
            var _clientFactory = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.google.com/search?q=kock&tbm=isch&ved=2ahUKEwiKjuKXxuXqAhWVsSoKHQ9_DscQ2-cCegQIABAA&oq=kock&gs_lcp=CgNpbWcQAzICCAAyAggAMgIIADICCAAyAggAMgIIADICCAAyAggAMgIIADICCAA6BQgAELEDUNArWN0uYLwyaABwAHgAgAF8iAHKA5IBAzAuNJgBAKABAaoBC2d3cy13aXotaW1nwAEB&sclient=img&ei=OqYaX4qJOJXjqgGP_rm4DA&safe=images&tbs=itp%3Aface&hl=en-US");
            _clientFactory.DefaultRequestHeaders.Clear();
            _clientFactory.DefaultRequestHeaders.Add("Connection", "keep-alive");
            _clientFactory.DefaultRequestHeaders.Add("Cache-Control", "max-age=0");
            _clientFactory.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
            _clientFactory.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.89 Safari/537.36");
            _clientFactory.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            _clientFactory.DefaultRequestHeaders.Add("X-Client-Data", "CI+2yQEIorbJAQjBtskBCKmdygEIiqzKAQjmxsoBCOfIygEIssnKAQi0y8oB");
            _clientFactory.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
            _clientFactory.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
            _clientFactory.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
            _clientFactory.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");
            _clientFactory.DefaultRequestHeaders.Add("Referer", "https://www.google.com/");
            _clientFactory.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9,sv;q=0.8,da;q=0.7");
            _clientFactory.DefaultRequestHeaders.Add("Cookie", "CGIC=EhQxQzFHQ0VBX2VuU0U4MTJTRTgxMiJ8dGV4dC9odG1sLGFwcGxpY2F0aW9uL3hodG1sK3htbCxhcHBsaWNhdGlvbi94bWw7cT0wLjksaW1hZ2Uvd2VicCxpbWFnZS9hcG5nLCovKjtxPTAuOCxhcHBsaWNhdGlvbi9zaWduZWQtZXhjaGFuZ2U7dj1iMztxPTAuOQ; CONSENT=WP.289366; NID=204=GWPD4hm9DhuAn70PwdyompsmTOBLSgxfdU0z6KI-X8cAodwJtflRDsBKSi8_KKk_7nLumJmpWcLSzo5n2QYmAHQdYjK59uwaS5FPbJZjCDElGBDQSRHDdW-sf8HeRuXGma4C0AaW_tWKEbQ7U7GXGR5uJ8DkZEGbVd2d7YqUfVM; 1P_JAR=2020-7-23-12; DV=Y6HYpkJTBJMoQIaWaSHSPtADEka6N5fug7JWUYEbdwEAAAA; UULE=a+cm9sZToxIHByb2R1Y2VyOjEyIHByb3ZlbmFuY2U6NiB0aW1lc3RhbXA6MTU5NTUwNzIzNzQ3MzAwMCBsYXRsbmd7bGF0aXR1ZGVfZTc6NTYwNzI2MDE2IGxvbmdpdHVkZV9lNzoxMjcyNzA5MTJ9IHJhZGl1czo0ODEwMjU3NjA=; OTZ=5553387_48_52_123900_48_436380");
            HttpResponseMessage response = await _clientFactory.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var collection = Regex.Matches(responseContent, @"(https?:\/\/.*\.(?:png|jpg))");
            }
        }
        public static void RestSharpGetGoogleImages()
        {
            var client = new RestClient("https://www.google.com/search?q=kock&tbm=isch&ved=2ahUKEwiKjuKXxuXqAhWVsSoKHQ9_DscQ2-cCegQIABAA&oq=kock&gs_lcp=CgNpbWcQAzICCAAyAggAMgIIADICCAAyAggAMgIIADICCAAyAggAMgIIADICCAA6BQgAELEDUNArWN0uYLwyaABwAHgAgAF8iAHKA5IBAzAuNJgBAKABAaoBC2d3cy13aXotaW1nwAEB&sclient=img&ei=OqYaX4qJOJXjqgGP_rm4DA&safe=images&tbs=itp%3Aface&hl=en-US");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Connection", "keep-alive");
            request.AddHeader("Cache-Control", "max-age=0");
            request.AddHeader("Upgrade-Insecure-Requests", "1");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.89 Safari/537.36";
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            request.AddHeader("X-Client-Data", "CI+2yQEIorbJAQjBtskBCKmdygEIiqzKAQjmxsoBCOfIygEIssnKAQi0y8oB");
            request.AddHeader("Sec-Fetch-Site", "same-origin");
            request.AddHeader("Sec-Fetch-Mode", "navigate");
            request.AddHeader("Sec-Fetch-User", "?1");
            request.AddHeader("Sec-Fetch-Dest", "document");
            request.AddHeader("Referer", "https://www.google.com/");
            request.AddHeader("Accept-Language", "en-US,en;q=0.9,sv;q=0.8,da;q=0.7");
            request.AddHeader("Cookie", "CGIC=EhQxQzFHQ0VBX2VuU0U4MTJTRTgxMiJ8dGV4dC9odG1sLGFwcGxpY2F0aW9uL3hodG1sK3htbCxhcHBsaWNhdGlvbi94bWw7cT0wLjksaW1hZ2Uvd2VicCxpbWFnZS9hcG5nLCovKjtxPTAuOCxhcHBsaWNhdGlvbi9zaWduZWQtZXhjaGFuZ2U7dj1iMztxPTAuOQ; CONSENT=WP.289366; NID=204=GWPD4hm9DhuAn70PwdyompsmTOBLSgxfdU0z6KI-X8cAodwJtflRDsBKSi8_KKk_7nLumJmpWcLSzo5n2QYmAHQdYjK59uwaS5FPbJZjCDElGBDQSRHDdW-sf8HeRuXGma4C0AaW_tWKEbQ7U7GXGR5uJ8DkZEGbVd2d7YqUfVM; 1P_JAR=2020-7-23-12; DV=Y6HYpkJTBJMoQIaWaSHSPtADEka6N5fug7JWUYEbdwEAAAA; UULE=a+cm9sZToxIHByb2R1Y2VyOjEyIHByb3ZlbmFuY2U6NiB0aW1lc3RhbXA6MTU5NTUwNzIzNzQ3MzAwMCBsYXRsbmd7bGF0aXR1ZGVfZTc6NTYwNzI2MDE2IGxvbmdpdHVkZV9lNzoxMjcyNzA5MTJ9IHJhZGl1czo0ODEwMjU3NjA=; OTZ=5553387_48_52_123900_48_436380");
            IRestResponse response = client.Execute(request);
            var responseContent = response.Content;

            var collection = Regex.Matches(responseContent, @"(https?:\/\/.*\.(?:png|jpg))");
            WebClient webClient = new WebClient();
            int i = 1;

            foreach (var imageLink in collection)
            {
                try
                {
                    webClient.DownloadFile(imageLink.ToString(), $"kock{i}.jpg");
                    i++;
                }
                catch
                {

                }

            }
        }
    }
}
