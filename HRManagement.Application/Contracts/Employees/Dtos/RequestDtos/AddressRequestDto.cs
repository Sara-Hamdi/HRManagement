namespace HRManagement.Application.Contracts.Employees.Dtos.RequestDtos
{
    public class AddressRequestDto
    {
        public required string City { get; set; }
        public required string Region { get; set; }
        public string? Notes { get; set; }
    }
}
