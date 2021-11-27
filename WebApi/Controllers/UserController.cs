using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DataAcces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserDAO dao;

        public UserController(IUserDAO dao)
        {
            this.dao = dao;
        }
        
        [HttpGet]
        public async Task<ActionResult<User>> GetUser([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                User user = new User {UserName = username, Password = password};
                User validate = await dao.ValidateUserAsync(user);
                return Ok(validate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

    }
}