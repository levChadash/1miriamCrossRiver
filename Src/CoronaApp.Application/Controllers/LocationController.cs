using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers;
[Authorize]
[Route("api/[controller]")]

[ApiController]

    // GET: api/<LocationController>

    public class LocationController : ControllerBase
    {
        private readonly ILocationRespository bl;

        public LocationController(ILocationRespository bl)
        {
            this.bl = bl;
        }
        // GET: api/<Location>
        [HttpGet]
        public async Task<List<Location>> GetLocations()
        {
            return await bl.Get();
        }

        // GET api/<Location>/5
        [HttpGet("city/{city}")]
        public async Task<List<Location>> GetLocationByCity(string city)
        {
            return await bl.GetByCity(city);
        }
        [HttpGet("id/{id}")]
        public async Task<List<Location>> getLocationById(string id)
        {
            return await bl.GetById(id);
        }

        [HttpGet("date")]
        public async Task<List<Location>> GetLocationByDate([FromBody] LocationSearch ls)
        {
            return await bl.GetByDate(ls);
        }
        [HttpGet("age")]
        public async Task<List<Location>> GetLocatinByAge([FromBody] LocationSearch ls)
        {
            return await bl.GetByAge(ls);
        }

        // POST api/<Location>
        [HttpPost]

        public void PostLocation([FromBody] Location location)
        {
            bl.Post(location);
        }

     

        // DELETE api/<Location>/5
        [HttpDelete]
        public async Task DeleteLocation([FromBody] Location l)
        {

            await bl.Delete(l);
        }
    }





