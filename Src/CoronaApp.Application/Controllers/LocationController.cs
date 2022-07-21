using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
        // GET: api/<LocationController>

        public class LocationController : ControllerBase
        {
            ILocationRespository bl;

            public LocationController(ILocationRespository bl)
            {
                this.bl = bl;
            }
            // GET: api/<Location>
            [HttpGet]
            public async Task<List<Location>> Get()
            {
                return await bl.get();
            }

            // GET api/<Location>/5
            [HttpGet("city/{city}")]
            public async Task<List<Location>> getByCity(string city)
            {
                return await bl.getByCity(city);
            }
            [HttpGet("id/{id}")]
            public async Task<List<Location>> getById(string id)
            {
                return await bl.getById(id);
            }

            [HttpGet("date")]
            public async Task<List<Location>> getByDate([FromBody] LocationSearch ls)
            {
                return await bl.getByDate(ls);
            }
            [HttpGet("age")]
            public async Task<List<Location>> getByAge([FromBody] LocationSearch ls)
            {
                return await bl.getByAge(ls);
            }

            // POST api/<Location>
            [HttpPost]

            public void Post([FromBody] Location location)
            {
                bl.post(location);
            }

            // PUT api/<Location>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }

            // DELETE api/<Location>/5
            [HttpDelete]
            public async Task Delete([FromBody] Location l)
            {

                await bl.delete(l);
            }
        }




    
}
