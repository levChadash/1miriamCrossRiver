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
[Authorize(Roles = "user")]
[Route("api/[controller]")]
[ApiController]

public class PatientController : ControllerBase
{
    private readonly IPatientRespository patientRespository;
    public PatientController(IPatientRespository patientRespository)
    {
        this.patientRespository = patientRespository;
    }
    // GET: api/<Patient>
    [HttpGet]
    public async Task<ActionResult<List<PatientDTO>>> GetAllPatients()
    {
        var patients = await patientRespository.GetAllPatients();
  
        if (patients == null)
        {
            return StatusCode(404, "not found");
        }
        if (!patients.Any())
        {
            return StatusCode(204, "no content");
        }
       
        return Ok(patients);
    }
    // POST api/<Patient>
    [HttpPost]
    public async Task<ActionResult<string>> AddPatient([FromBody] Patient patient)
    {
        
        var patientFound = await patientRespository.AddPatient(patient);
        if (patientFound == null)
        {
            return StatusCode(404, "not found");
        }
        if (!patientFound.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(patientFound);
    }
}