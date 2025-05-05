using HRManagement.Application.Reports.Interfaces;
using HRManagement.Domain.ExternalServices;

namespace HRManagement.Application.Reports
{
    public class ReportAppService : IReportAppService
    {

        private readonly IReportService _reportService;
        public ReportAppService(IReportService reportService)
        {
            _reportService = reportService;
        }
        public async Task<byte[]> ExportEmployeesSalaries(Guid? departmentId = null)
        {
            string reportName = "EmployeesSalaries";
            Dictionary<String, string> paramsList = new()
            {
                {"DepartmentId",departmentId.ToString() }
            };
            return await _reportService.GetReportPdfAsync(reportName, paramsList);

        }
    }
}
