using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Admin.Database;
using Admin.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;    
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers.API.Authorization
{
    [Authorize]
    [ApiController]
    [Route("api/auth")]
    public sealed class UsersController : ControllerBase
    {
        private readonly ApplicationContext _db;

        public UsersController(ApplicationContext userContext)
        {
            _db = userContext;
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthorizationModel model, CancellationToken cancellationToken)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Username == model.Username,
                cancellationToken);

            var message = user == null ? "Can't find this user" : $"Found user {user.Username}";

            return Ok(message);

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model, CancellationToken cancellationToken)
        {
            return Ok(null);
        }
    }
}