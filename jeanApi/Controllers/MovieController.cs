using Jean.Core.Interface;
using Jean.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace jeanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController(IMovieService movieService, IHistoryService historyService) : ControllerBase
    {
        private readonly IMovieService _movieService = movieService;
        private readonly IHistoryService _historyService = historyService;


        [HttpGet("search")]
        public async Task<IActionResult> SearchMovies(string title)
        {
            var result = await _movieService.SearchMoviesAsync(title);
            await _historyService.AddSearchQueryAsync(title);
            return Ok(result);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> MovieDetails(string id)
        {
            var result = await _movieService.GetMovieDetailsAsync(id);
            return Ok(result);
        }

    }
}
