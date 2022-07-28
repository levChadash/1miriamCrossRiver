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
    
    [Authorize]
    [HttpGet("name")]
    public  async Task<ActionResult<string>> GetNameByToken()
    {

        var result=await userResposetory.GetNameByToken(User);

        if (result == null)
        {
            return StatusCode(404, "not found");
        }
        if (!result.Any())
        {
            return StatusCode(204, "no content");
        }
        return Ok(result.ToString());
    }


   

    [HttpPost("login")]
    public async Task<ActionResult<string>> LogIn([FromBody] User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException("no details for user");
        }
        var result = await userResposetory.LogIn(user);
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

    // Post: User
    [HttpPost("signUp")]
    public async Task<ActionResult<string>> SignUp([FromBody] User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException("no user details");
        }
        var result = await userResposetory.SignUp(user);
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
}

