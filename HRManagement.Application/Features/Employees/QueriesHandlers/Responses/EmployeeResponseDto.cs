namespace HRManagement.Application.Features.Employees.QueriesHandlers.Responses
{
    public class EmployeeResponseDto
    {
        public required string FullName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Department { get; set; }
        public double NetSalary { get; set; }
        public double GrossSalary { get; set; }
        public required string Position { get; set; }
        public AddressResponseDto? Address { get; set; }
    }
}
