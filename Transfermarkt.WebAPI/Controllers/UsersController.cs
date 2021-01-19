using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Transfermarkt.Models.Requests;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Services;

namespace Transfermarkt.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IData<Roles> _serviceRole;
        private readonly IData<UsersRoles> _serviceUsersRoles;

        public UsersController(IUserService userService, IData<Roles> serviceRole, IData<UsersRoles> serviceUsersRoles)
        {
            _userService = userService;
            _serviceRole = serviceRole;
            _serviceUsersRoles = serviceUsersRoles;
        }

        [HttpPost("registration")]
        [AllowAnonymous]
        public Users UserRegister(Models.UserRegistration userRequest)
        {
            var obj = _userService.RegisterUser(userRequest);
            Users user = new Users
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

        [HttpGet]
        public List<UserInfo> GetUsers([FromQuery] UserSearchRequest request)
        {
            var query = _userService.GetUsers().AsQueryable();

            if(request.Username != null || request.FirstName != null || request.LastName != null || request.Username != null)
            {
                query = query.Where(x => 
                            x.FirstName.ToLower().StartsWith(request.FirstName) ||
                            x.LastName.ToLower().StartsWith(request.LastName) ||
                            x.Email.ToLower().StartsWith(request.Email) ||
                            x.Username.ToLower().StartsWith(request.Username)
                    );
            }

            var users = query
                .OrderByDescending(x => x.JoinDate)
                .Select(x => new UserInfo {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    JoinDate = x.JoinDate,
                    LastName = x.LastName,
                    Username = x.Username,
                    Roles = string.Join(",", x.UsersRoles.Select(r => r.Role.Name))
                })
                .ToList();

            return users;
        }

        [HttpGet("CheckRole")]
        [AllowAnonymous]
        public bool GetRole([FromQuery] UserRoleCheck userRole)
        {
            return _userService.IsAdmin(userRole);
        }

        //[HttpGet]
        //[Authorize]
        //public User GetUserInfo()
        //{
        //    //ovo user je sada moj UserId
        //    var user = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
        //}
    }
}