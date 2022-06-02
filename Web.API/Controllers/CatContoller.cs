using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;
using Web.API.Model;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatContoller : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory; //services.addhttpclient()
        private readonly ILogger<CatContoller> _logger;
        private readonly IConfiguration _configuration; //appsettings.json
        public CatContoller(IHttpClientFactory httpClientFactory, ILogger<CatContoller> logger, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "Get")]
        public async Task<CatFacts> Get()
        {
            var cats = await GetCats();
            _logger.LogInformation("Log");

            return cats;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<CatFacts> GetCats()
        {
            try
            {
                var url = _configuration["CatUrl"];
                HttpResponseMessage response = await _httpClientFactory.CreateClient().GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseMessage = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<CatFacts>(responseMessage, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return data;
                }

            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}