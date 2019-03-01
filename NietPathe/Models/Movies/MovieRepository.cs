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

        public Movie CreateMovie(Movie movie)
        {   
            _dataContext.Movies.InsertOneAsync(movie);
            return movie;
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

        public async Task<Movie> GetMovieById(string id)
        {
            FilterDefinition<Movie> filter = Builders<Movie>.Filter.Eq(m => m.Id, id);
            return await _dataContext.Movies.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _dataContext.Movies.Find(_ => true).ToListAsync();
        }

        public bool UpdateMovie(Movie movie)
        {
            FilterDefinition<Movie> filter = Builders<Movie>.Filter.Eq(m => m.Id, movie.Id);
            ReplaceOneResult replaceOneResult = _dataContext.Movies.ReplaceOneAsync(filter, movie).Result;
            return replaceOneResult.IsAcknowledged && replaceOneResult.IsModifiedCountAvailable;
        }

        public async Task<List<Movie>> GetPaginatedMovies(int skip)
        {
            return await _dataContext.Movies.Find(_ => true)
                .Sort("{year: -1}")
                .Skip(skip)
                .Limit(25)
                .ToListAsync();
        }

        public async Task<int> TotalMovies()
        {
            var longboy = await _dataContext.Movies.CountDocumentsAsync(_ => true);
            return (int)longboy;
        }
    }
}
