using HRManagement.Application.Baeses;
using HRManagement.Application.Contracts.Departments.Dtos.QueryDtos;
using HRManagement.Application.Contracts.Departments.Dtos.RequestDtos;
using HRManagement.Application.Contracts.Departments.Dtos.ResponseDtos;
using HRManagement.Application.Contracts.Departments.Interfaces;
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
        public async Task<PaginatedResult<DepartmentResponseDto>> GetDepartmentsAsync([FromQuery] DepartmentQueryDto request)
        {
            return await _departmentAppService.GetDepartmentsAsync(request);
        }
        [HttpPost]
        [Authorize(Roles = Constants.Roles.Admin)]
        public async Task<Guid> CreateDepartmentsAsync([FromBody] CreateDepartmentRequestDto request)
        {
            return await _departmentAppService.CreateDepartmentAsync(request);
        }
    }
}
