using HRManagement.Application.Users.Dtos;
using HRManagement.Application.Users.Interfaces;
using HRManagement.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = Constants.Roles.Admin)]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserRequestDto request)
        {
            await _userAppService.RegisterUserAsync(request);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserInfoAsync(string id, [FromBody] UpdateUserInfoRequestDto request)
        {
            request.UserId = id;
            await _userAppService.UpdateUserInfo(request);
            return Ok();
        }
    }
}
