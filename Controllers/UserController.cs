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

        public static readonly List<User> users = new List<User> { new Models.User() { UserId = "1", FirstName = "Andrei", LastName = "Valeriu", Email = "andrei.valeriu@gmail.com", Password = "1234", Pwd ="1234" } };

        [HttpGet]
        public IActionResult GetUser([FromBody]User loginUser)  
        {
            var User = users.FirstOrDefault(i=>i.UserId==loginUser.UserId);
            if (User == null)
            {
                return NotFound("Invalid user ID");
            }
            return Ok(loginUser);
        }
        [HttpGet]
        [Route("{UserId}")]

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            newUser.UserId = System.Guid.NewGuid().ToString();
            users.Add(newUser);
            return Ok();
            
        }
    }
}
