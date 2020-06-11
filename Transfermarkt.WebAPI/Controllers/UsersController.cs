using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("registration")]
        [AllowAnonymous]
        public User UserRegister(UserRegistration userRequest)
        {
            var obj = _userService.RegisterUser(userRequest);
            User user = new User
            {
                Id = obj.Id,
                Username = obj.Username,
                Email = obj.Email,
                LastName = obj.LastName,
                FirstName = obj.FirstName
            };
            return user;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(UserLoginModel model)
        {
            var user = _userService.Authenticate(model);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            return Ok(user);
        }
    }
}