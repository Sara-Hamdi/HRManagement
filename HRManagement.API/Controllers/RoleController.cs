using HRManagement.Application.Baeses;
using HRManagement.Application.Contracts.Roles.Dtos.QueryDtos;
using HRManagement.Application.Contracts.Roles.Dtos.ResponseDtos;
using HRManagement.Application.Contracts.Roles.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.API.Controllers
{
    [Route("hr-management/api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleAppService _roleAppService;
        public RoleController(IRoleAppService roleAppService)
        {
            _roleAppService = roleAppService;
        }
        [HttpGet]
        public async Task<PaginatedResult<RoleResponseDto>> GetRolesAsync([FromQuery] RoleQueryDto request)
        {
            return await _roleAppService.GetRolesAsync(request);
        }
    }
}
