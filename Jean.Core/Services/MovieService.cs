using Jean.Core.Interface;
using Jean.Data.dto;
using Jean.Model.Domains;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Jean.Core.Services
{
    public class MovieService(HttpClient httpClient, IConfiguration configuration) : IMovieService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string _apiKey = configuration["OmDb:ApiKey"];
        private readonly string _baseUrl = "http://www.omdbapi.com/";


        public async Task<Movie> GetMovieDetailsAsync(string imdbID)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}?i={imdbID}&apikey={_apiKey}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"failed to get response with status code {response.StatusCode}");
                }

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Movie>(content);

                if (result == null)
                {
                    throw new ApplicationException("Failed to parse movie details");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving movie details", ex.InnerException);
            }
        }


        public async Task<IEnumerable<Movie>> SearchMoviesAsync(string title)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}?s={title}&apikey={_apiKey}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"failed to get response with status code {response.StatusCode}");
                }

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<SearchResult>(content);

                if (result == null || result.Search == null)
                {
                    throw new ApplicationException("Failed to parse movie search results");
                }

                return result.Search;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while searching for movies", ex.InnerException);
            }
        }
    }
}
