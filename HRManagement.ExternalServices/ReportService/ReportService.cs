using HRManagement.Domain.ExternalServices;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Security.Principal;
using System.ServiceModel;

namespace HRManagement.ExternalServices.ReportService
{
    public class ReportService : IReportService

    {
        private readonly IConfiguration _configuration;

        public ReportService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<byte[]> GetReportPdfAsync(string reportName, Dictionary<string, string>? parameters = null)
        {
            var reportServerUrl = _configuration["ReportServer:ReportServerUrl"];
            var reportPath = _configuration["ReportServer:ReportFolderPath"];

            var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly)
            {
                Security = { Transport = { ClientCredentialType = HttpClientCredentialType.Ntlm } },
                MaxReceivedMessageSize = 10485760

            };
            var endpoint = new EndpointAddress(reportServerUrl);
            var client = new ReportExecutionServiceSoapClient(binding, endpoint);

            // Option 1: Use specific credentials
            client.ClientCredentials.Windows.ClientCredential = new NetworkCredential("username", "password", "domain");

            // Option 2: Use current user (impersonation)
            client.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Impersonation;
            client.ClientCredentials.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;
            // 1. Load the report
            var loadResult = await client.LoadReportAsync(null, "/" + reportPath + "/" + reportName, null);

            // 2. Set parameters (if provided)
            if (parameters is not null && parameters.Count > 0)
            {
                var parameterList = parameters.Select(p => new ParameterValue
                {
                    Name = p.Key,
                    Value = p.Value
                }).ToArray();

                await client.SetExecutionParametersAsync(new ExecutionHeader { ExecutionID = loadResult.ExecutionHeader.ExecutionID }, null, parameterList, "en-us");
            }

            // 3. Render to PDF
            var renderResult = await client.RenderAsync(new RenderRequest
            {
                ExecutionHeader = new ExecutionHeader { ExecutionID = loadResult.ExecutionHeader.ExecutionID },
                Format = "PDF",
                DeviceInfo = "<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>"
            });

            return renderResult.Result;
        }

    }
}

