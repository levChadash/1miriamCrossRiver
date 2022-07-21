using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class LocationRespository : ILocationRespository
    {
        IDalLocation dal;
        public LocationRespository(IDalLocation Dal)
        {
            this.dal = Dal;
        }
        public async Task post(Location location)
        {
              await dal.post(location);
        }
        public async Task<List<Location>> get()
        {
            return await dal.get();
        }
        public async Task<List<Location>> getByCity(string city)
        {
            city = city.ToLower();

            return await dal.getByCity(city);
        }
        public async Task<List<Location>> getById(string id)
        {
            return await dal.getById(id);
        }
        public async Task<List<Location>> getByDate(LocationSearch ls)
        {
            return await dal.getByDate(ls);
        }
        public async Task<List<Location>> getByAge(LocationSearch ls)
        {
            return await dal.getByAge(ls);
        }
        public async Task delete(Location l)
        {
             await dal.delete(l);
        }
    }
}
