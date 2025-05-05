namespace HRManagement.Application.Reports.Interfaces
{
    public interface IReportAppService
    {
        Task<byte[]> ExportEmployeesSalaries(Guid? departmentId = null);

    }
}
