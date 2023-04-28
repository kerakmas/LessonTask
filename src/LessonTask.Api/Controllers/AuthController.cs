using LessonTask.Service.DTOs.Login;
using LessonTask.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LessonTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(LoginDto dto)
        {
            return Ok(await this._authService.AuthenticateAsync(dto.Email, dto.Password));
        }
    }
}
