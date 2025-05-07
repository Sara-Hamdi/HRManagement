using HRManagement.Application.Employees.Dtos.RequestDtos;
using MediatR;

namespace HRManagement.Application.Users.Dtos
{
    public class RegisterUserRequestDto : IRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Password { get; set; }
        public required string ConfirmedPassword { get; set; }
        public string? Role { get; set; }
        public required Guid PositionId { get; set; }
        public required Guid DepartmentId { get; set; }
        public required CreateEmployeeRequestDto EmployeeDetails { get; set; }
    }
}
