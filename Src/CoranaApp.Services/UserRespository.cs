using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                        new Claim("id", user.Id.ToString()),
                        new Claim("Role","user"),
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

    public async Task<string> LogIn(User user)
    {
        User userFound = await dal.LogIn(user);
        if (userFound != null)
        {
            return await CreatToken(userFound);
        }
        else
        {
            return null;
        }
    }

    public async Task<string> SignUp(User user)
    {
        if (await dal.LogIn(user) == null)
        {
            await dal.SignUp(user);

            return await LogIn(user);
        }
        else
        {
            return await LogIn(user);
        }

    }
   public async Task<string> GetNameByToken(ClaimsPrincipal user)
    {
        var userName= user.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Name", StringComparison.InvariantCultureIgnoreCase));
        if (userName != null)
        {
            return userName.ToString();
        }
        else
        {
            return null;
        }
    }
}

