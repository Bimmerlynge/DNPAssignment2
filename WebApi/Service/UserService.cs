using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Service
{
    public class UserService : IUserService
    {

        private List<User> users;

        public UserService()
        {
            users = new[]
            {
                new User
                {
                    UserName = "Henning",
                    Password = "1234",
                    Role = "Member",
                    SecurityLevel = 1
                },
                new User {
                    UserName = "Admin",
                    Password = "Admin",
                    Role = "Admin",
                    SecurityLevel = 11
                }
            }.ToList();
        }
        
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            User tmp = users.FirstOrDefault(user => user.UserName.Equals(username));
            if (tmp == null)
                throw new Exception($"No account by username: {username}");
            if (!tmp.Password.Equals(password))
                throw new Exception("Incorrect Password");
            return tmp;
        }
    }
}