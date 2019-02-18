using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace NietPathe.Models
{
    public class DataContext : IDataContext
    {
        private readonly IMongoDatabase _db;

        public DataContext(IOptions<Settings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<Movie> Movies => _db.GetCollection<Movie>("movies");
        public IMongoCollection<Performance> Performances => _db.GetCollection<Performance>("performances");
        public IMongoCollection<Hall> Halls => _db.GetCollection<Hall>("halls");
        public IMongoCollection<Ticket> Tickets => _db.GetCollection<Ticket>("tickets");
    }
}
