using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public class Mock : IDalLocation
{

    Patient p1 = new Patient() { Id = "324103357", Name = "Miriam", DateOfBirth=new DateTime() };
    Patient p2 = new Patient() { Id = "324864800", Name = "Leah", DateOfBirth = new DateTime() };
    Patient p3 = new Patient() { Id = "212825376", Name = "Shani", DateOfBirth = new DateTime() };
    Location l1;
    List<Patient> pl;
    List<Location> lc;


    public Mock()
    {
        List<Patient> pl = new List<Patient>();
        List<Location> lc = new List<Location>();
        Location l1 = new Location()
        {
            LocaionId = 1,
            Address = "libary",
            City = "ny",
            PatientId = "324103357",
            StartDate = new DateTime(),
            EndDate = new DateTime(),
            Patient = new Patient() { Id = "324103357", Name = "Miriam", DateOfBirth = new DateTime() },
        };
        pl.Add(p1);
        pl.Add(p2);
        pl.Add(p3);
        lc.Add(l1);
    }
    public Task Delete(Location l)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Location>> GetLocations()
    {
       return lc;
    }

    public Task<List<Location>> GetByAge(LocationSearch ls)
    {
        throw new NotImplementedException();
    }

    public Task<List<Location>> GetByCity(string city)
    {
        throw new NotImplementedException();
    }

    public Task<List<Location>> GetByDate(LocationSearch ls)
    {
        throw new NotImplementedException();

    }
    public Task<List<Location>> GetByStartDate(LocationSearch ls)
    {
        throw new NotImplementedException();
    }
    public Task<List<Location>> GetByEndDate(LocationSearch ls)
    {
        throw new NotImplementedException();
    }


    public Task<List<Location>> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<int> AddLocation(Location location)
    {
        throw new NotImplementedException();
    }

    public Task DeleteLocation(Location l)
    {
        throw new NotImplementedException();
    }
}
