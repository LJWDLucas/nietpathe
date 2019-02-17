using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NietPathe.Models.Movies
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies();
        Task<IEnumerable<Movie>> GetActiveMoviesWithLimit(int limit);
        Task<Movie> GetMovieByTitle(string title);
        void CreateMovie(Movie movie);
        Task<bool> UpdateMovie(Movie product);
        Task<bool> DeleteMovie(string name);
    }
}
