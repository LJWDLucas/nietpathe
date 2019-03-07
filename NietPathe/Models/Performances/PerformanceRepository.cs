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

        public void CreatePerformance(Performance performance)
        {
            _dataContext.Performances.InsertOne(performance);
        }

        public async Task<Performance> GetPerformance(string id)
        {
            FilterDefinition<Performance> filter = Builders<Performance>.Filter.Eq(p => p.Id, id);
            return await _dataContext.Performances.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<List<Performance>> GetPerformances()
        {
            return await _dataContext.Performances.Find(_ => true).ToListAsync();
        }

        public async Task <List<Performance>> GetPerformancesAfterDate(DateTime date)
        {
            FilterDefinition<Performance> filter =
                Builders<Performance>.Filter.Gt(p => p.StartTime, date);
            return await _dataContext.Performances.Find(filter).ToListAsync();
        }

        public async Task<List<Performance>> GetPerformancesBeforeDate(DateTime date)
        {
            FilterDefinition<Performance> filter =
                Builders<Performance>.Filter.Lt(p => p.StartTime, date);
            return await _dataContext.Performances.Find(filter).ToListAsync();
        }

        public async Task<List<Performance>> GetPerformancesByDate(DateTime date)
        {
            var startSpan = new TimeSpan(0, 0, 0);
            var endSpan = new TimeSpan(23, 59, 59);
            var start = date.Date + startSpan;
            var end = date.Date + endSpan;
            FilterDefinition<Performance> filter =
                Builders<Performance>.Filter.Gte(p => p.StartTime, start) &
                Builders<Performance>.Filter.Lt(p => p.StartTime, end);
            return await _dataContext.Performances.Find(filter).ToListAsync();
        }

        public async Task<List<Performance>> GetPerformancesByHallId(string id)
        {
            FilterDefinition<Performance> filter = Builders<Performance>.Filter.Eq(p => p.HallId, id);
            return await _dataContext.Performances.Find(filter).ToListAsync();
        }

        public async Task<List<Performance>> GetPerformancesByMovieId(string id)
        {
            FilterDefinition<Performance> filter =
                Builders<Performance>.Filter.Eq(p => p.MovieId, id);
            return await _dataContext.Performances.Find(filter).ToListAsync();
        }

        public void UndoBooking(PerformanceChair chair, string id)
        {
            var filter = Builders<Performance>.Filter.Where(performance => performance.Id == id && performance.Chairs.Any(c => c.Chair == chair.Chair && c.Row == chair.Row));
            var update = Builders<Performance>.Update.Set(performance => performance.Chairs[-1].Taken, false)
                .Set(performance => performance.Chairs[-1].TicketId, "");
            var result = _dataContext.Performances.UpdateOneAsync(filter, update).Result;
        }
    }
}
