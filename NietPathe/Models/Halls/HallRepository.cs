using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace NietPathe.Models.Halls
{
    public class HallRepository : IHallRepository
    {
        private readonly IDataContext _dataContext;

        public HallRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Hall>> GetAllHalls()
        {
            return await _dataContext.Halls.Find(_ => true).ToListAsync();
        }

        public async Task<Hall> GetHallbyId(string id)
        {
            FilterDefinition<Hall> filter = Builders<Hall>.Filter.Eq(h => h.Id, id);
            return await _dataContext.Halls.Find(filter).FirstOrDefaultAsync();
        }
    }
}
