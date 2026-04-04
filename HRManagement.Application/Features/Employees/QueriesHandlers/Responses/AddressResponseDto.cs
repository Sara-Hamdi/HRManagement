namespace HRManagement.Application.Features.Employees.QueriesHandlers.Responses
{
    public class AddressResponseDto
    {
        public required string Region { get; set; }
        public required string City { get; set; }
        public string? Notes { get; set; }
    }
}
