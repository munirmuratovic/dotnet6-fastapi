using AspnetCoreTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AspnetCoreTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FastApiController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FastApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        [HttpPost]
        public async Task<string> PostAsync([FromBody] string name)
        {
            var httpClient = _httpClientFactory.CreateClient();
            using var request = new HttpRequestMessage(new HttpMethod("POST"), "http://127.0.0.1:8000/");
            var newItem = new Item {
                Name = name,
            };
            var jsonString = JsonSerializer.Serialize(newItem);
            request.Content = new StringContent(jsonString);
            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            var response = await httpClient.SendAsync(request);

            var contents = await response.Content.ReadAsStringAsync();
            return contents;
        }
    }
}
