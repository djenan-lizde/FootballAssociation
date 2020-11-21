using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Transfermarkt.Models.Requests;
using Transfermarkt.Models.Responses;
using Transfermarkt.WebAPI.Configuration;
using System.Collections.Generic;
using Transfermarkt.WebAPI.Exceptions;
using Transfermarkt.WebAPI.Database;
using Transfermarkt.WebAPI.Encryption;

namespace Transfermarkt.WebAPI.Services
{
    public interface IUserService
    {
        UserAuthenticationResult Authenticate(UserLoginModel model);
        Users RegisterUser(Models.UserRegistration user);
        List<Users> GetUsers();
        bool IsAdmin(UserRoleCheck userRole);
    }
    public class UserService : IUserService
    {
        protected readonly FootballAssociationDbContext _context;

        private readonly IOptions<AppSettings> _options;

        public UserService(FootballAssociationDbContext context, IOptions<AppSettings> options)
        {
            _context = context;
            _options = options;
        }
        public UserAuthenticationResult Authenticate(UserLoginModel model)
        {
            var user = _context.Users
                .Include(x => x.UsersRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefault(x => x.Username == model.Username);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            if (user.PasswordHash != HashGenSalt.GenerateHash(user.PasswordSalt, model.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                }),
                Issuer = _options.Value.Issuer,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserAuthenticationResult
            {
                Id = user.Id,
                Token = tokenHandler.WriteToken(token),
                Username = user.Username
            };
        }
        public Users RegisterUser(Models.UserRegistration userRegister)
        {
            var userInDbUserName = _context.Users.FirstOrDefault(x => x.Username == userRegister.Username);
            var userInDbEmail = _context.Users.FirstOrDefault(x => x.Email == userRegister.Email);

            if (userInDbUserName != null)
                throw new UserException("Username already in use!");

            if (userInDbEmail != null)
                throw new UserException("Email already in use!");

            if (userRegister.Password != userRegister.PasswordConfirmation)
            {
                throw new UserException("Passwords do not match!");
            }
            var user = new Users
            {
                Email = userRegister.Email,
                Username = userRegister.Username,
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName,
                JoinDate = DateTime.Now
            };

            user.PasswordSalt = HashGenSalt.GenerateSalt();
            user.PasswordHash = HashGenSalt.GenerateHash(user.PasswordSalt, userRegister.Password);

            _context.Users.Add(user);
            _context.SaveChanges();

            foreach (var role in userRegister.Roles)
            {
                UsersRoles usersRoles = new UsersRoles
                {
                    UserId = user.Id,
                    RoleId = role
                };
                _context.UsersRoles.Add(usersRoles);
            }
            _context.SaveChanges();

            return user;
        }
        public List<Users> GetUsers()
        {
            return _context.Users.ToList();
        }
        public bool IsAdmin(UserRoleCheck userRole)
        {
            var user = _context.UsersRoles.Include(x => x.Role).Include(x => x.User)
                .FirstOrDefault(x => x.User.Username == userRole.Username && x.Role.Name == userRole.Rolename);

            if (user == null)
                return false;

            if (user.Role.Name == userRole.Rolename)
                return true;

            return false;
        }
    }
}
