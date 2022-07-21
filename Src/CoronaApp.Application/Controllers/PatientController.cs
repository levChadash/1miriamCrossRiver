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

    public class PatientController : ControllerBase
    {
        IPatientRespository bl;
        public PatientController(IPatientRespository bl)
        {
            this.bl = bl;
        }
        // GET: api/<Patient>
        [HttpGet]
        public Task<List<Patient>> Get()
        {

            return bl.get();
        }



        // POST api/<Patient>
        [HttpPost]
        public void Post([FromBody] Patient patient)
        {
            bl.post(patient);
        }
    }
}
