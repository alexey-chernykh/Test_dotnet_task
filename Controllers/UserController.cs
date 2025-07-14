using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_dotnet_task.Services;

namespace Test_dotnet_task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet("/users")]
        public IEnumerable<User> Get()
        {
            return _userService.GetAllUsers();
        }

        [HttpPost("/users")]
        public User Post([FromBody] UserRequest request)
        {
            return _userService.CreateUser(request.Name);
        }
    }
}
