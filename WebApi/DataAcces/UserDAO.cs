using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Persistence;

namespace WebAPI.DataAcces
{
    public class UserDao : IUserDAO
    {

        private List<User> users;

        public UserDao()
        {
            using MyDBContext databaseContext = new MyDBContext();
            User lookUp = databaseContext.Users.FirstOrDefault(user => user.UserName.Equals("Admin")); 
            
            if (lookUp == null)
            {
                databaseContext.Users.Add(new User
                {
                    UserName = "Admin",
                    Password = "Admin",
                    Role = "Admin",
                    SecurityLevel = 11
                });
                databaseContext.Users.Add(new User()
                {
                    UserName = "Henning",
                    Password = "1234",
                    Role = "Member",
                    SecurityLevel = 1
                });
                databaseContext.SaveChanges(); 
            }
        }
        
        public async Task<User> ValidateUserAsync(User user)
        {
            using (MyDBContext context = new MyDBContext())
            {
                User toReturn = context.Users.FirstOrDefault(u => u.UserName.Equals(user.UserName) && u.Password.Equals(user.Password));
                return toReturn;
            }
        }
    }
}