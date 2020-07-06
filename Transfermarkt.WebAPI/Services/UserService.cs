using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Transfermarkt.Models;
using Transfermarkt.Models.Requests;
using Transfermarkt.Models.Responses;
using Transfermarkt.WebAPI.Configuration;
using Transfermarkt.WebAPI.Database;
using System.Collections.Generic;
using Transfermarkt.WebAPI.Exceptions;

namespace Transfermarkt.WebAPI.Services
{
    public interface IUserService
    {
        UserAuthenticationResult Authenticate(UserLoginModel model);
        User RegisterUser(UserRegistration user);
        List<User> GetUsers();
    }
    public class UserService : IUserService
    {
        protected readonly AppDbContext _context;

        private readonly IOptions<AppSettings> _options;

        public UserService(AppDbContext context, IOptions<AppSettings> options)
        {
            _context = context;
            _options = options;
        }
        public UserAuthenticationResult Authenticate(UserLoginModel model)
        {
            var user = _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefault(x => x.Username == model.Username);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            if (user.PasswordHash != GenerateHash(user.PasswordSalt, model.Password))
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
        public User RegisterUser(UserRegistration userRegister)
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
            var user = new User
            {
                Email = userRegister.Email,
                Username = userRegister.Username,
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName,
                JoinDate = DateTime.Now
            };

            user.PasswordSalt = GenerateSalt();
            user.PasswordHash = GenerateHash(user.PasswordSalt, userRegister.Password);

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
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
