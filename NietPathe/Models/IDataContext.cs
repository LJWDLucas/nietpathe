using System;
using MongoDB.Driver;

namespace NietPathe.Models
{
    public interface IDataContext
    {
        IMongoCollection<Movie> Movies { get; }
    }
}