namespace HRManagement.Domain.Aggregates.DepartmentAggregate
{
    public class DepartmentManager
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentManager(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<Guid> CreateAsync(string nameAr, string nameEn)
        {
            var department = new Department(Guid.NewGuid(), nameAr, nameEn);
            return await _departmentRepository.CreateDepartmentAsync(department);

        }
    }
}
