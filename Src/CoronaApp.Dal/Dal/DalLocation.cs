
using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public class DalLocation : IDalLocation
{

    CoronaAppContext _context;

    public DalLocation(CoronaAppContext context)
    {
        _context = context;
    }
    

    public async Task<List<Location>> GetLocations()
    {
        using (var _CoronaAppContext = new CoronaAppContext())
        {
            List<Location> listLocations = await _CoronaAppContext.Locations.ToListAsync();
            if (listLocations.Count == 0)
                return null;
            return listLocations;
        }

       

    }

    public async Task<List<Location>> GetByCity(string city)
    {

        List<Location> lc = await _context.Locations.Where(c => c.City.ToLower() == city).ToListAsync();
        if (lc.Count == 0)
            return null;
        return lc;

    }
    public async Task<List<Location>> GetById(string id)
    {
        List<Location> lc = await _context.Locations.Where(c => c.PatientId == id).ToListAsync();
        if (lc.Count == 0)
            return null;
        return lc;
    }
    public async Task<List<Location>> GetByDate(LocationSearch ls)
    {
        List<Location> lc = await _context.Locations.Where(c => c.StartDate >= ls.StartDate).
            Where(c => c.EndDate <= ls.EndDate)
            .ToListAsync();
        if (lc.Count == 0)
            return null;
        return lc;
    }
    public async Task<List<Location>> GetByStartDate(LocationSearch ls)
    {
        List<Location> lc = await _context.Locations.Where(c => c.StartDate >= ls.StartDate)
            .ToListAsync();
        if (lc.Count == 0)
            return null;
        return lc;
    }
    public async Task<List<Location>> GetByEndDate(LocationSearch ls)
    {
        List<Location> lc = await _context.Locations.
            Where(c => c.EndDate <= ls.EndDate)
            .ToListAsync();
        if (lc.Count == 0)
            return null;
        return lc;
    }
    public async Task<List<Location>> GetByAge(LocationSearch ls)
    {
        List<Location> lc = await _context.Locations.Where(c => c.Patient.Age == ls.Age)
            .ToListAsync();
        if (lc.Count == 0)
            return null;
        return lc;
    }

    public async Task<int> AddLocation(Location location)
    {
        try
        {
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();

            return location.LocaionId;
        }
        catch 
        {
            throw new Exception("faild saving location");
        }
    }

    public async Task DeleteLocation(Location l)
    {
        try
        {
            _context.Locations.Remove(l);
            await _context.SaveChangesAsync();
        }
        catch 
        {
            throw new Exception("didnt mange to delete location");
        }
    }


}