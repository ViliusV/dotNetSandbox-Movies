using Movies.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Data
{
    public class DatabaseInitializer
    {
        public static void Initialize(MoviesContext context)
        {
            context.Database.EnsureCreated();

            if (context.Movies.Any())
            {
                return;
            }
            var movies = new Movie[]
            {
                new Movie { Title = "Godfather", Country = "US", Year = 1971 },
                new Movie { Title = "Lord of the Rings", Country = "US", Year = 2001 },
                new Movie { Title = "Monty Python's Life of Brian", Country = "UK", Year = 1979},
                new Movie { Title = "Unusual Suspects", Country = "US", Year = 1994 },
                new Movie { Title = "American Beauty", Country = "US", Year = 1999 },
                new Movie { Title = "Amélie", Country = "France", Year = 2001 }
            };

            context.Movies.AddRange(movies);

            context.SaveChanges();
        }
    }
}
