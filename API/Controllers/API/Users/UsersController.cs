using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Admin.Database;
using Admin.Models.User;
using Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;    
using Microsoft.EntityFrameworkCore;

namespace Admin.Controllers.API.Users
{
    [Authorize]
    [ApiController]
    [Route("api/auth")]
    public sealed class UsersController : ControllerBase
    {
        private readonly ApplicationContext _db;

        private readonly IUserService _userService;

        public UsersController(ApplicationContext userContext, IUserService userService)
        {
            _db = userContext;

            _userService = userService;
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthorizationModel model, CancellationToken cancellationToken)
        {
            var data = await _userService.AuthenticateUser(model.Username, model.Password);

            if (data == null)
            {
                return Forbid();
            }
            
            if (!data.Approved)
            {
                return Unauthorized("Waiting for approval.");
            }

            return Ok(data);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model, 
            CancellationToken cancellationToken)
        {
            var data = await _userService.RequestRegister(model);

            if (data == null)
            {
                return Forbid();
            }

            return Ok(data);
        }
    }
}