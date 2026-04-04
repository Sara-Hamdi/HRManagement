using HRManagement.Contract.Baeses;

namespace HRManagement.Application.Contracts.Employees.Dtos.RequestDtos
{
    public class EmployeeQueryParamsDto : PaginatingQueryDto
    {
        public Guid? DepartmentId { get; set; }
    }
}
