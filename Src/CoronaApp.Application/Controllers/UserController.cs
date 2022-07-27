using CoronaApp.Dal.Models;
using CoronaApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace CoronaApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]


public class UserController : ControllerBase
{
    IUserRespository userResposetory;
    public UserController(IUserRespository userResposetory)
    {
        this.userResposetory = userResposetory;
    }
    // GET: api/<LoginController>
    [HttpGet("/name")]
    [Authorize]
    public string GetNameByToken()
    {
        var userName = User.Claims.FirstOrDefault(
                  x => x.Type.ToString().Equals("Name", StringComparison.InvariantCultureIgnoreCase));
        
      if(userName != null)
        {
            return userName.ToString();
        }
        return null;
        

    }

    // GET api/<LoginController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<LoginController>
    [HttpPost("/signUp")]
    public async Task<string> signUp([FromBody] User user)
    {
        
        return await userResposetory.Post(user);
    }

    [HttpPost("login/")]
    public async Task<IActionResult> PostLogin([FromBody] User user)
    {
        string token = await userResposetory.PostLogIn(user);
        if (token == null)
            return NotFound();
        return Ok(token);
    }

    // PUT api/<LoginController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<LoginController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}

