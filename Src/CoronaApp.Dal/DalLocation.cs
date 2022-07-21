using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace CoronaApp.Dal
{
    public class DalLocation : IDalLocation
    {

        CoronaAppContext _context;

        public DalLocation(CoronaAppContext context)
        {
            _context = context;
        }


        public async Task<List<Location>> get()
        {
            return   await _context.Locations.ToListAsync();

        }

        public async Task<List<Location>> getByCity(string city)
        {

            List<Location> lc = await _context.Locations.Where(c => c.City == city).ToListAsync();
            return lc;

        }
        public async Task<List<Location>> getById(string id)
        {
            List<Location> lc = await _context.Locations.Where(c => c.PatientId == id).ToListAsync();
            return lc;
        }
        public async Task<List<Location>> getByDate(LocationSearch ls)
        {
            List<Location> lc = await _context.Locations.Where(c => c.StartDate >= ls.StartDate).
                Where(c=>c.EndDate<=ls.EndDate)
                .ToListAsync();
            return lc;
        }
        public async Task<List<Location>> getByAge(LocationSearch ls)
        {
            List<Location> lc = await _context.Locations.Where(c => c.Patient.Age == ls.Age)
                .ToListAsync();
            return lc;
        }
        public  async Task post(Location location)
        {
              await _context.Locations.AddAsync(location);
             await _context.SaveChangesAsync();
        }

        public async Task delete(Location l)
        {
              _context.Locations.Remove(l);
           await _context.SaveChangesAsync();
        }


    }
}