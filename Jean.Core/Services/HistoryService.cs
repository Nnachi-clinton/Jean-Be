using Jean.Core.Interface;
using Jean.Data.context;
using Jean.Model.Domains;
using Microsoft.EntityFrameworkCore;

namespace Jean.Core.Services
{
    public class HistoryService(JeanDbContext context) : IHistoryService
    {
        private readonly JeanDbContext _context = context;
        private readonly int _maxCount = 5;

        public async Task AddSearchQueryAsync(string query)
        {
            var history = new History
            {
                Search = query,
                SearchTime = DateTime.Now
            };

            _context.Histories.Add(history);
            await _context.SaveChangesAsync();

            var queryCount = await _context.Histories.CountAsync();
            if (queryCount > _maxCount)
            {
                var oldestQuery = await _context.Histories.OrderBy(q => q.SearchTime).FirstOrDefaultAsync();
                _context.Histories.Remove(oldestQuery);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<History>> GetRecentSearchQueriesAsync()
        {
            return await _context.Histories
                .OrderByDescending(q => q.SearchTime)
                .Take(5)
                .ToListAsync();
        }
    }
}
