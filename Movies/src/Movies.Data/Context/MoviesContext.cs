using Microsoft.EntityFrameworkCore;
using Movies.Domain;

namespace Movies.Data
{
    public class MoviesContext: DbContext
    {
        public DbSet<Movie> Movies{ get; set; }

        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {
        }
    }
}
