using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.DataAcces
{
    public interface IUserDAO
    {
        Task<User> ValidateUserAsync(User user);
    }
}