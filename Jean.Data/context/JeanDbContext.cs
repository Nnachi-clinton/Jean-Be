using Jean.Model.Domains;
using Microsoft.EntityFrameworkCore;

namespace Jean.Data.context
{
    public class JeanDbContext(DbContextOptions<JeanDbContext> options) : DbContext(options)
    {
        public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
