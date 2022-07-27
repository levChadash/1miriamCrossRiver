using CoronaApp.Dal.Models;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public interface IDalUser
    {
        Task<User> PostLogIn(User user);
        Task AddUser(User user);
    }
}