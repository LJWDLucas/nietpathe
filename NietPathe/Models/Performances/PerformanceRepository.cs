using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using MongoDB.Driver;
using MongoDB.Bson;

namespace NietPathe.Models.Performances
{
    public class PerformanceRepository : IPerformanceRepository
    {
        private readonly IDataContext _dataContext;

        public PerformanceRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void BookPerformanceSeat(PerformanceChair chair, string id)
        {
            var filter = Builders<Performance>.Filter.Where(performance => performance.Id == id && performance.Chairs.Any(c => c.Chair == chair.Chair && c.Row == chair.Row));
            var update = Builders<Performance>.Update.Set(performance => performance.Chairs[-1].Taken, true)
                .Set(performance => performance.Chairs[-1].TicketId, chair.TicketId);
            var result = _dataContext.Performances.UpdateOneAsync(filter, update).Result;
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
