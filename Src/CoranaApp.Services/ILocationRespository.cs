using CoronaApp.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Services;

public interface ILocationRespository
{
    Task Delete(Location l);
    Task<List<Location>> GetLocations();
    Task<List<Location>> GetByCity(string city);
    Task<List<Location>> GetById(string id);
    Task<int> AddLocation(Location location);
    Task<List<Location>> GetByDate(LocationSearch ls);
    Task<List<Location>> GetByAge(LocationSearch ls);
   
}