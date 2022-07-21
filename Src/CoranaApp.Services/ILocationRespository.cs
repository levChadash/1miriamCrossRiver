using CoronaApp.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface ILocationRespository
    {
        Task delete(Location l);
        Task<List<Location>> get();
        Task<List<Location>> getByCity(string city);
        Task<List<Location>> getById(string id);
        Task post(Location location);
        Task<List<Location>> getByDate(LocationSearch ls);
        Task<List<Location>> getByAge(LocationSearch ls);
    }
}