using LessonTask.Domain.Configurations;
using LessonTask.Service.DTOs;
using LessonTask.Service.DTOs.Users;
using LessonTask.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace LessonTask.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(UserCreationDto userCreationDto)
        {
            return Ok(await this._userService.AddAsync(userCreationDto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBydIdAsync(int id)
        {
            return Ok(await this._userService.RetrieveByIdAsync(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(await this._userService.RemoveAsync(id));
        }
        [HttpGet] 
        public async Task<IActionResult> GetAllAsync([FromQuery]PaginationParamas @params)
        {
            return Ok(await this._userService.RetrieveAllAsync(@params));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, UserCreationDto dto)
        {
            return Ok(await this._userService.ModifyAsync(id, dto));
        }


    }
}
