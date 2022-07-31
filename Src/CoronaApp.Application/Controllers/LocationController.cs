using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CoronaApp.Dal.Models;
using CoronaApp.Services;
using CoronaApp.Services.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoronaApp.Api.Controllers;
[Authorize (Roles="user")]
[Route("api/[controller]")]

[ApiController]

// GET: api/<LocationController>

public class LocationController : ControllerBase
{
    private readonly ILocationRespository locationRespository;

    public LocationController(ILocationRespository locationRespository)
    {
        this.locationRespository = locationRespository;
    }
    // GET: api/<Location>
    [HttpGet]
    public async Task<ActionResult<List<Location>>> GetLocations()
    {
        var result = await locationRespository.GetLocations();
        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }
    // GET api/<Location>/5
    [HttpGet("city/{city}")]
    public async Task<ActionResult<List<Location>>> GetLocationByCity(string city)
    {
        if (city == null)
        {
            throw new ArgumentNullException("no city");
        }

        var result = await locationRespository.GetByCity(city);

        if (result == null)
        {
            return StatusCode(404, "not found");
        }

        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }

        return Ok(result);
    }
    [HttpGet("id/{id}")]
    public async Task<ActionResult<List<Location>>> GetLocationsByPatientId(string id)
    {
        if (id == null)
        {
            throw new ArgumentNullException("id");
        }
        var result = await locationRespository.GetById(id);

        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);

    }

    [HttpPost("date")]
    public async Task<ActionResult<List<Location>>> GetLocationSBetweenDates([FromBody] LocationSearch ls)
    {
        if (ls.StartDate != null && ls.EndDate != null)
        {
            if (DateTime.Compare(ls.StartDate, ls.EndDate) < 0)
            {
                return StatusCode(500, "not a valid arguments");
            }
        }

        var result = await locationRespository.GetByDate(ls);
        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }
    [HttpPost("age")]
    public async Task<ActionResult<List<Location>>> GetLocationsByAge([FromBody] LocationSearch ls)
    {
        var result = await locationRespository.GetByAge(ls);
        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }


    // POST api/<Location>
    
    [HttpPost]
    public async Task<ActionResult<int>> AddLocation([FromBody] LocationPostDTO locationDTO)
    {
   
        if (DateTime.Compare(locationDTO.StartDate, locationDTO.EndDate) < 0)
        {
            throw new Exception("not a valid argument");
        }

        var result = await locationRespository.AddLocation(locationDTO);
        if (result == 0)
        {
            return StatusCode(404, "not found");
        }
        if (result == 0)
        {
            return StatusCode(204, "no content");
        }
        return Ok(result);
    }




    // DELETE api/<Location>/5
    [HttpDelete]
    public async Task DeleteLocation([FromBody] Location location)
    {
        await locationRespository.Delete(location);
    }
}












