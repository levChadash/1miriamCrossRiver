using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services;

public class LocationRespository : ILocationRespository
{
    IDalLocation dal;
    public LocationRespository(IDalLocation Dal)
    {
        this.dal = Dal;
    }
    public async Task<int> AddLocation(Location location)
    {
           return await dal.AddLocation(location);
    }
    public async Task<List<Location>> GetLocations()
    {
        return await dal.GetLocations();
    }
    public async Task<List<Location>> GetByCity(string city)
    {
        city = city.ToLower();

        return await dal.GetByCity(city);
    }
    public async Task<List<Location>> GetById(string id)
    {
        return await dal.GetById(id);
    }
    public async Task<List<Location>> GetByDate(LocationSearch ls)
    {
        if (ls.StartDate == null)
        {
            return await dal.GetByStartDate(ls);
        }
        if (ls.EndDate == null)
        {
            return await dal.GetByEndDate(ls);
        }
        return await dal.GetByDate(ls);
    }
    public async Task<List<Location>> GetByAge(LocationSearch ls)
    {
        return await dal.GetByAge(ls);
    }
    public async Task Delete(Location l)
    {
         await dal.DeleteLocation(l);
    }
}
