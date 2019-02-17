using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace NietPathe.Models.Movies
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IDataContext _dataContext;

        public MovieRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async void CreateMovie(Movie movie)
        {
            await _dataContext.Movies.InsertOneAsync(movie);
        }

        public Task<bool> DeleteMovie(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetActiveMoviesWithLimit(int limit)
        {
            FilterDefinition<Movie> filter = Builders<Movie>.Filter.Eq(m => m.Active, true);
            return await _dataContext.Movies.Find(filter).Limit(limit).ToListAsync();
        }

        public async Task<Movie> GetMovieByTitle(string title)
        {
            FilterDefinition<Movie> filter = Builders<Movie>.Filter.Eq(m => m.Title, title);
            return await _dataContext.Movies.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _dataContext.Movies.Find(_ => true).ToListAsync();
        }

        public Task<bool> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
