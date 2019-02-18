using System;
using System.Threading.Tasks;

namespace NietPathe.Models.Halls
{
    public interface IHallRepository
    {
        Task<Hall> GetHallbyId(string id);
   }
}
