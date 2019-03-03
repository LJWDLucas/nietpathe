using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NietPathe.Models.Halls
{
    public interface IHallRepository
    {
        Task<Hall> GetHallbyId(string id);
        Task<List<Hall>> GetAllHalls();
   }
}
