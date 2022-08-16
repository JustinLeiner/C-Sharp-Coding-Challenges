using System;
using System.Linq.Expressions;
using System.Text;

namespace AcmeFlix.Repositories
{
    public class InMemoryMovieRepository : IMovieRepository
    {
        private static List<MovieManagement> movies = new List<MovieManagement>
       {
           new MovieManagement
           {
               Id = 1,
               Name = "Inception",
               Director = "Christopher Nolan",
               ReleaseDate = "10/22/2011",
               Tags = new List<string>{"Time", "Mind-Blowing", "Impactful", "Dreams"},
               ReviewCount = 24
           },

           new MovieManagement
           {
               Id = 2,
               Name = "The Batman",
               Director = "Matt Reeves",
               ReleaseDate = "12/08/2021",
               Tags = new List<string> {"Moody", "Dark", "Mind-Blowing", "Impactful"},
               ReviewCount = 11
           }
       };

        public List<MovieManagement> Add(MovieManagement movie)
        {
            movies.Add(movie);
            return movies;
        }

        public List<MovieManagement> Delete(MovieManagement movie)
        {
            movies.Remove(movie);
            return movies;
        }

        public List<MovieManagement> GetAll()
        {
            return movies;
        }

        public MovieManagement Update(MovieManagement movie, MovieManagement requestChanges)
        {
            movie.Name = requestChanges.Name;
            movie.Director = requestChanges.Director;
            movie.ReleaseDate = requestChanges.ReleaseDate;
            movie.Tags = requestChanges.Tags;
            movie.ReviewCount = requestChanges.ReviewCount;

            // Need to fix this
            return movie;
        }
    }
}

