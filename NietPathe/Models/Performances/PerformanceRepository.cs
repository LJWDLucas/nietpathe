using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using MongoDB.Driver;

namespace NietPathe.Models.Performances
{
    public class PerformanceRepository : IPerformanceRepository
    {
        private readonly IDataContext _dataContext;

        public PerformanceRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Performance> GetPerformance(string id)
        {
            FilterDefinition<Performance> filter = Builders<Performance>.Filter.Eq(p => p.Id, id);
            return await _dataContext.Performances.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<Performance>> GetPerformancesByDate(string date)
        {
            FilterDefinition<Performance> filter =
                Builders<Performance>.Filter.Eq(p => p.StartTime, date);
            return await _dataContext.Performances.Find(filter).ToListAsync();
        }

        public async Task<List<Performance>> GetPerformancesByMovieId(string id)
        {
            FilterDefinition<Performance> filter =
                Builders<Performance>.Filter.Eq(p => p.MovieId, id);
            return await _dataContext.Performances.Find(filter).ToListAsync();
        }

    }
}
