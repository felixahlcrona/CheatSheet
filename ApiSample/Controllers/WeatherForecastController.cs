using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public static HttpClient _client = new HttpClient();

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public class Drink
        {
            public int price { get; set; }
        }
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [Route("GetRequestSingleton")]
        [HttpGet]
        public async Task<string> GetRequestSingleton()
        {
            HttpResponseMessage response = await _client.GetAsync("http://www.google.com/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }

        [Route("GetRequestNewInstance")]
        [HttpGet]
        public async Task<string> GetRequestNewInstance()
        {
            HttpClient localClient = new HttpClient();
            HttpResponseMessage response = await localClient.GetAsync("http://www.google.com/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
     
        [HttpPost]
        public string PostAsync(Drink data)
        {
            var request = HttpContext.Request;
            var userAgent = request.Headers.Where(e => e.Key == "User-Agent").FirstOrDefault().Value.FirstOrDefault().ToString();

            return userAgent;
        }
    }
}
