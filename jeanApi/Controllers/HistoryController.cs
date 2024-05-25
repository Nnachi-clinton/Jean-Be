using Jean.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace jeanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController(IHistoryService historyService) : ControllerBase
    {
        private readonly IHistoryService _historyService = historyService;

        [HttpGet("history")]
        public IActionResult GetSearchHistory()
        {
            var history = _historyService.GetRecentSearchQueriesAsync();
            return Ok(history);
        }
}   }
