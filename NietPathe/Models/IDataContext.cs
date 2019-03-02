using System;
using MongoDB.Driver;
using NietPathe.Models.Surveys;

namespace NietPathe.Models
{
    public interface IDataContext
    {
        IMongoCollection<Movie> Movies { get; }
        IMongoCollection<Performance> Performances { get; }
        IMongoCollection<Survey> Surveys { get; }
        IMongoCollection<Ticket> Tickets { get; }
        IMongoCollection<Hall> Halls { get; }
        IMongoCollection<Review> Reviews { get; }
    }
}
