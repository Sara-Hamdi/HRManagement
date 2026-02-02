namespace HRManagement.Application.Features.Reports.Interfaces
{
    public interface IReportAppService
    {
        Task<byte[]> ExportEmployeesSalaries(Guid? departmentId = null);

    }
}
