using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PassionProjectN01664066.Services
{
    public class OmdbService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "a84b565";

        public OmdbService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://www.omdbapi.com/");
        }

        public async Task<string> SearchMovies(string searchTerm)
        {
            try
            {
                var response = await _httpClient.GetAsync($"?apikey={ApiKey}&s={Uri.EscapeDataString(searchTerm)}");
                var content = await response.Content.ReadAsStringAsync();

                System.Diagnostics.Debug.WriteLine($"OMDB API Raw Response: {content}");

                return content;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception in OMDB API call: {ex.Message}");
                return $"{{ \"Error\": \"Exception occurred: {ex.Message}\" }}";
            }
        }
    }
}