using HRManagement.Application.Features.Users.CommandHandlers.Commands;
using HRManagement.Application.Users.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.API.Controllers
{
    [Route("hr-management/api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserCommand request)
        {
            await _userAppService.RegisterUserAsync(request);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserInfoAsync(string id, [FromBody] UpdateUserInfoCommand request)
        {
            request.UserId = id;
            await _userAppService.UpdateUserInfo(request);
            return Ok();
        }
        [HttpPut("change-password/{id}")]
        public async Task<IActionResult> ChangeUserPasswordAsync(string id, [FromBody] ChangeUserPasswordCommand request)
        {
            request.UserId = id;
            await _userAppService.ChangeUserPasswordAsync(request);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<string> LoginUser([FromBody] LoginUserCommand request)
        {
            return await _userAppService.LoginUser(request);
        }
    }
}
