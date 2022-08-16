using System;
using System.Linq.Expressions;

namespace AcmeFlix.Repositories
{
    public interface IMovieRepository
    {
        public List<MovieManagement> Add(MovieManagement movie);
        public MovieManagement Update(MovieManagement movie, MovieManagement requestChanges);
        public List<MovieManagement> Delete(MovieManagement movie);
        public List<MovieManagement> GetAll();

    }
}

