using CoronaApp.Dal.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoronaApp.Services;

    public interface IUserRespository
    {
        Task<string> PostLogIn(User user);
        Task<string> Post(User user);
    }
        
