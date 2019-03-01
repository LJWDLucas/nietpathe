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
        Task<Movie> GetMovieById(string id);
        Movie CreateMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        Task<bool> DeleteMovie(string name);
        Task<List<Movie>> GetPaginatedMovies(int skip);
        Task<int> TotalMovies();
    }
}
