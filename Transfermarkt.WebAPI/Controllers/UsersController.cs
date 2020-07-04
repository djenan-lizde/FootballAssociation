using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly IData<Role> _serviceRole;
        private readonly IData<UsersRoles> _serviceUsersRoles;

        public UsersController(IUserService userService, IData<Role> serviceRole, IData<UsersRoles> serviceUsersRoles)
        {
            _userService = userService;
            _serviceRole = serviceRole;
            _serviceUsersRoles = serviceUsersRoles;
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

        [HttpGet]
        public List<UserInfo> GetUsers([FromQuery]UserSearchRequest request)
        {
            var query = _userService.GetUsers().AsQueryable();

            if (request.Username == null && request.FirstName == null && request.LastName == null && request.Username == null)
            {
                return GetUserInfos(query.ToList());
            }

            query = query.Where(x => x.FirstName.ToLower().StartsWith(request.FirstName) ||
                        x.LastName.ToLower().StartsWith(request.LastName) ||
                        x.Email.ToLower().StartsWith(request.Email) ||
                        x.Username.ToLower().StartsWith(request.Username)).OrderByDescending(x => x.JoinDate);

            return GetUserInfos(query.ToList());
        }

        private List<UserInfo> GetUserInfos(List<User> users)
        {
            List<UserInfo> list = new List<UserInfo>();

            foreach (var item in users)
            {
                var userRoles = _serviceUsersRoles.GetByCondition(x => x.UserId == item.Id);
                var userInfo = new UserInfo
                {
                    Id = item.Id,
                    Email = item.Email,
                    FirstName = item.FirstName,
                    JoinDate = item.JoinDate,
                    LastName = item.LastName,
                    Username = item.Username
                };
                foreach (var item2 in userRoles)
                {
                    var role = _serviceRole.GetById(item2.RoleId);
                    userInfo.Roles = string.Join(',', role.Name);
                }
                list.Add(userInfo);
            }
            return list;
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