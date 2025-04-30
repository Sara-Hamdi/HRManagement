using static HRManagement.Domain.Shared.Enums;

namespace HRManagement.Application.Employees.Dtos.RequestDtos
{
    public class EmployeeQueryDto
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public SortingDirection SortingDirection { get; set; }
        public string? SearchKey { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
