using Jean.Model.Domains;

namespace Jean.Core.Interface
{
    public interface IMovieService
    {
        public Task<Movie> GetMovieDetailsAsync(string imdbID);
        public Task<IEnumerable<Movie>> SearchMoviesAsync(string title);
        

    }
}
