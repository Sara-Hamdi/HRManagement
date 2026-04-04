using HRManagement.Application.Baeses;
using HRManagement.Application.Contracts.Roles.Interfaces;
using HRManagement.Application.Features.Roles.QueryHandlers.Queries;
using HRManagement.Application.Features.Roles.QueryHandlers.Responses;
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
        public async Task<PaginatedResult<RoleResponseDto>> GetRolesAsync([FromQuery] GetRolesQuery request)
        {
            return await _roleAppService.GetRolesAsync(request);
        }
    }
}
