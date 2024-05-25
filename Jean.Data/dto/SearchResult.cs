using Jean.Model.Domains;

namespace Jean.Data.dto
{
    public class SearchResult
    {
        public List<Movie> Search { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }
    }

}
