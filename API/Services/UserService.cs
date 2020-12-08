using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Admin.Database;
using Admin.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Admin.Helpers;
using Admin.Models.User.Info;
using Microsoft.Extensions.Options;

namespace Admin.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _db;

        private readonly AppSettings _appSettings;
        
        public UserService(ApplicationContext userContext, IOptions<AppSettings> appSettings)
        {
            _db = userContext;
            _appSettings = appSettings.Value;
        }
        
        public async Task<User> AuthenticateUser(string uname, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => 
                x.Username == uname && x.Password == password);

            if (user == null)
                return null;
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            await _db.SaveChangesAsync();

            return user;
        }

        public async Task<User> RequestRegister(RegistrationModel model)
        {
            var exists = await _db.Users.FirstOrDefaultAsync(x => 
                x.Username == model.Username) != null;

            if (exists)
                return null;
            
            var user = await _db.Users.AddAsync(new User
                {
                    Username = model.Username,
                    Password = model.Password,
                    Role = Role.ADMIN
                });

            await _db.SaveChangesAsync();
            
            return user.Entity;
        }
    }
}