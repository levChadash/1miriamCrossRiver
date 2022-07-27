using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

 public class Mock : IDalLocation
{
    
    Patient p1 = new Patient() { Id = "324103357", Name = "Miriam", Age = 9 };
    Patient p2 = new Patient() { Id = "324864800", Name = "Leah", Age = 9 };
    Patient p3 = new Patient() { Id = "212825376", Name = "Shani", Age = 9 };
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
            Patient = new Patient() { Id = "324103357", Name = "Miriam", Age = 9 },
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

    public async  Task<List<Location>> Get()
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

    public Task<List<Location>> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task Post(Location location)
    {
        throw new NotImplementedException();
    }
}
