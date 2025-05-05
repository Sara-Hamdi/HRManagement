using HRManagement.Application.Reports.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRManagement.API.Controllers
{
    [Route("hr-management/api/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportAppService _reportAppService;
        public ReportController(IReportAppService reportAppService)
        {
            _reportAppService = reportAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesSalaries([FromQuery] Guid? departmentId)
        {

            var report = await _reportAppService.ExportEmployeesSalaries(departmentId);
            return File(report, "application/pdf", $"EmployeesSalaries.pdf");
        }

    }
}
