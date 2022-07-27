using CoronaApp.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public interface IDalLocation
{
    Task Delete(Location l);
    Task<List<Location>> Get();
    Task<List<Location>> GetByCity(string city);
    Task<List<Location>> GetById(string id);
    Task Post(Location location);
    Task<List<Location>> GetByDate(LocationSearch ls);
    Task<List<Location>> GetByAge(LocationSearch ls);



}