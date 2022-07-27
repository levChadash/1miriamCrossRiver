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

public class PatientController : ControllerBase
{
    private readonly IPatientRespository bl;
    public PatientController(IPatientRespository bl)
    {
        this.bl = bl;
    }
    // GET: api/<Patient>
    [HttpGet]
    public Task<List<Patient>> GetPatients()
    {

        return bl.Get();
    }



    // POST api/<Patient>
    [HttpPost]
    public void PostPatients([FromBody] Patient patient)
    {
        bl.Post(patient);
    }
}