using Jean.Model.Domains;

namespace Jean.Core.Interface
{
    public interface IHistoryService
    {
        public Task AddSearchQueryAsync(string query);
        public Task<List<History>> GetRecentSearchQueriesAsync();
    }
}
