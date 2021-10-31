using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<User>> GetUser([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                User validate = await service.ValidateUserAsync(username, password);
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