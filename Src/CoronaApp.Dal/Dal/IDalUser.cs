using CoronaApp.Dal.Models;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public interface IDalUser
    {
        Task<User> LogIn(User user);
        Task SignUp(User user);
    }
}