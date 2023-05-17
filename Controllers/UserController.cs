using DAWM_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAWM_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;

        public UserController(IConfiguration config)
        {
            _config = config;
        }

        public static readonly List<User> users = new List<User> { new Models.User() { Id = 1, firstName = "Andrei", lastName = "Valeriu", email = "andrei.valeriu@gmail.com", password = "1234"} };

        [HttpGet]
        public IActionResult GetUsers()  
        {
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            users.Add(newUser);
            return Ok(newUser);
            
        }
    }
}
