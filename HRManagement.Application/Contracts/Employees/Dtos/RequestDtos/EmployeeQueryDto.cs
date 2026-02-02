using HRManagement.Application.Baeses;

namespace HRManagement.Application.Contracts.Employees.Dtos.RequestDtos
{
    public class EmployeeQueryDto : PaginatingQueryDto
    {
        public Guid? DepartmentId { get; set; }
    }
}
