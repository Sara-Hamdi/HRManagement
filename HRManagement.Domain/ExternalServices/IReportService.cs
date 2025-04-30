namespace HRManagement.Domain.Services
{
    public interface IReportService
    {
        Task<byte[]> GetReportPdfAsync(string reportName, Dictionary<string, string>? parameters = null);
    }
}
