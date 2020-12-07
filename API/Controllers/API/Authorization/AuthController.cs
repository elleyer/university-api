using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Admin.Database.User;
using Admin.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers.API.Authorization
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class AuthController : ControllerBase
    {
        private readonly UserContext _db;

        public AuthController(UserContext userContext)
        {
            _db = userContext;
        }
        
        [HttpPost("login")]
        public async Task<string> Login([FromBody] LoginForm loginForm)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Username == loginForm.Username);
            return user == null ? "Invalid username or password" : "Success!";
        }
        
        [HttpPost("register")]
        public string Register([FromBody] LoginForm loginForm)
        {
            return "gotcha";
        }
    }
}