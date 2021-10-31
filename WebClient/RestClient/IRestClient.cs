using System.Collections.Generic;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.RestClient
{
    public interface IRestClient
    {
        Task AddAdultAsync(Adult newAdultItem);
        Task<IList<Adult>> GetAdults();
        Task Remove(int id);
        Task<User> ValidateUser(string username, string password);
    }
}