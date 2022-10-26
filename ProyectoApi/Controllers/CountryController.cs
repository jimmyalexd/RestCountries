using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProyectoApi.Models;
using System.Net.Http;

namespace ProyectoApi.Controllers
{
    [ApiController]
    [Route("country")]
    public class CountryController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _countryPath = "Countries";
        public CountryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCountries()
        {

            try
            {

                var response = await Get();
                
                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
                        
        }

        private async Task<List<ApiRestCountryResponse>> Get()
        {
            var client = _httpClientFactory.CreateClient(_countryPath);
            var response = await client.GetAsync("all?fields=name,capital,population");
            string content = await response.Content.ReadAsStringAsync();
            var countries = JsonConvert.DeserializeObject<List<ApiRestCountryResponse>>(content);

            return countries;
        }

    }
}
