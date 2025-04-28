using E_commerce.Core.DTO;
using E_commerce.Core.Service_Contracts;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid Data");
            }

            var user = await userService.Login(request);
            if (user == null || user.succes == false)
            {
                return Unauthorized(request);
            }
            return Ok(user);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid Data");
            }

            var user = await userService.Register(request);
            if (user == null || user.succes == false)
            {
                return BadRequest(request);
            }
            return Ok(user);
        }
    }
}
