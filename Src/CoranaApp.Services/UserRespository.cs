using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services;

public class UserRespository : IUserRespository
{
    IDalUser dal;
    IConfiguration _configuration;
    public UserRespository(IDalUser dal, IConfiguration configuration)
    {
        this.dal = dal;
        this._configuration = configuration;
    }
    public async Task<string> CreatToken(User user)
    {
        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Name", user.UserName.ToString()),
                        new Claim("id", user.Id.ToString())
                    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: signIn);

        return new JwtSecurityTokenHandler().WriteToken(token);

    }
    public async Task<string> PostLogIn(User user)
    {
        User userFound = await dal.PostLogIn(user);
        if (userFound == null)
            return null;
        return await CreatToken(userFound);
    }
    public async Task<User> CheckUser(User user)
    {
        User userFound = await this.dal.PostLogIn(user);
            if(userFound == null)
                 return null;
            return userFound;

    }
     public async Task<string> Post(User user)
    {
        if(CheckUser(user)==null)
        await this.dal.AddUser(user);
        return await PostLogIn(user);
    }
   /* public string getUserName(PEHeaders headers)
    {


        return headers;
    }*/
}

