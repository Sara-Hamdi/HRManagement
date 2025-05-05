namespace HRManagement.Domain.ExternalServices
{
    public interface IReportService
    {
        Task<byte[]> GetReportPdfAsync(string reportName, Dictionary<string, string>? parameters = null);
    }
}
