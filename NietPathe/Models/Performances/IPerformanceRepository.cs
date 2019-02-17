using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NietPathe.Models.Performances
{
    public interface IPerformanceRepository
    {
        Task<Performance> GetPerformance(string id);
        Task<List<Performance>> GetPerformancesByDate(string date);
        Task<List<Performance>> GetPerformancesByMovieId(string id);
    }
}
