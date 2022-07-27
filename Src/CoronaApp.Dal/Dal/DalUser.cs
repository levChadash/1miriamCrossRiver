using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public class DalUser : IDalUser
{
    CoronaAppContext _context;
    public DalUser(CoronaAppContext context)
    {
        _context = context;
    }
    public async Task<User> PostLogIn(User user)
    {
        User u = await _context.Users.FirstOrDefaultAsync(us => us.UserName.Equals(user.UserName) && us.Password.Equals(user.Password));
        if(u == null)
            return null;
        return u;
    }
    public async Task AddUser(User user)
    {
        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        catch
        {
            throw new Exception();
        }
      
    }
}

