using Jean.Core.Interface;
using Jean.Core.Services;
using Jean.Data.context;
using Microsoft.EntityFrameworkCore;

namespace jeanApi.Extension
{
    public static class ServiceExtention
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<MovieService>();
            services.AddControllers();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IHistoryService, HistoryService>();
            services.AddControllers();
            services.AddDbContext<JeanDbContext>(options =>
                options.UseSqlite("Data Source=Jean.db"));

        }
    }
}
