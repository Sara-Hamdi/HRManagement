using HRManagement.Application.Baeses;
using HRManagement.Application.Departments.Interfaces;
using HRManagement.Application.Features.Departments.CommandsHandlers.Commands;
using HRManagement.Application.Features.Departments.QueryHandlers.Queries;
using HRManagement.Application.Features.Departments.QueryHandlers.Responses;
using HRManagement.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.API.Controllers
{
    [Route("hr-management/api/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentAppService _departmentAppService;
        public DepartmentController(IDepartmentAppService departmentService)
        {
            _departmentAppService = departmentService;
        }
        [HttpGet]
        [Authorize]
        public async Task<PaginatedResult<DepartmentResponseDto>> GetDepartmentsAsync([FromQuery] GetDepartmentsQuery request)
        {
            return await _departmentAppService.GetDepartmentsAsync(request);
        }
        [HttpPost]
        [Authorize(Roles = Constants.Roles.Admin)]
        public async Task<Guid> CreateDepartmentsAsync([FromBody] CreateDepartmentCommand request)
        {
            return await _departmentAppService.CreateDepartmentAsync(request);
        }
    }
}
