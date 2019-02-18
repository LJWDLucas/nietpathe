using System;
using MongoDB.Driver;

namespace NietPathe.Models
{
    public interface IDataContext
    {
        IMongoCollection<Movie> Movies { get; }
        IMongoCollection<Performance> Performances { get; }
        IMongoCollection<Ticket> Tickets { get; }
        IMongoCollection<Hall> Halls { get; }
    }
}
