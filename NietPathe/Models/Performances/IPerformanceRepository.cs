using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NietPathe.Models.Performances
{
    public interface IPerformanceRepository
    {
        Task<Performance> GetPerformance(string id);
        Task<List<Performance>> GetPerformances();
        Task<List<Performance>> GetPerformancesBeforeDate(DateTime date);
        Task<List<Performance>> GetPerformancesAfterDate(DateTime date);
        Task<List<Performance>> GetPerformancesByDate(DateTime date);
        Task<List<Performance>> GetPerformancesByHallId(string id);
        Task<List<Performance>> GetPerformancesByMovieId(string id);
        void CreatePerformance(Performance performance);
        void BookPerformanceSeat(PerformanceChair chair, string id);
    }
}
