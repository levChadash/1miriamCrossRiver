using CoronaApp.Dal.Models;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoronaApp.Services;

    public interface IUserRespository
    {
        Task<string> LogIn(User user);
        Task<string> SignUp(User user);
        Task<string> GetNameByToken(ClaimsPrincipal user);
}
        
