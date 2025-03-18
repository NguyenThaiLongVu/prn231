using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRN231.Entities;
using PRN231.Requests;
using PRN231.Services;

namespace PRN231.Api
{
    [Route("api/users")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private IUserService _userService;

        public UserApiController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            User user = await _userService.GetUserByUsernameAndPassword(login);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            User user = await _userService.GetUserByIdAsync(id);
            return Ok(user);
        }
        [HttpGet("")]
        public async Task<IActionResult> GetUsers([FromQuery] string search="")
        {
            var user = await _userService.GetUsersAsync(search ?? string.Empty);
            return Ok(user);
        }
        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await _userService.AddUserAsync(user);
            return Ok();
        }
        [HttpPost("update-user")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            await _userService.UpdateUserAsync(user);
            return Ok();
        }
    }
}
