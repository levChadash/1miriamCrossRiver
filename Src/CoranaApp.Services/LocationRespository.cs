using AutoMapper;
using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services;

public class LocationRespository : ILocationRespository
{
   private readonly IDalLocation dal;
    private readonly IMapper mapper;
    public LocationRespository(IDalLocation Dal,IMapper mapper)
    {
        this.dal = Dal;
        this.mapper = mapper;
    }
    public async Task<int> AddLocation(LocationPostDTO locationDTO)
    {
        Location location =  mapper.Map<Location>(locationDTO);
        
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
        if (ls.StartDate== null)
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
