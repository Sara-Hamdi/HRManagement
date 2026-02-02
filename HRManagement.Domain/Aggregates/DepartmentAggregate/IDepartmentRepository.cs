using static HRManagement.Shared.Enums;

namespace HRManagement.Domain.Aggregates.DepartmentAggregate
{
    public interface IDepartmentRepository
    {
        Task<Guid> CreateDepartmentAsync(Department department);
        Task<Department> GetDepartmentByIdAsync(Guid id);
        Task<(int totalCount, List<Department> departments)> GetDepartmentsAsync(int pageSize, int pageNumber, SortingDirection? sortingDirection, string? searchKey = null);
    }
}
