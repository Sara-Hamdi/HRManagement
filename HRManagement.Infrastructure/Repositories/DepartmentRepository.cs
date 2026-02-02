using HRManagement.Domain.Aggregates.DepartmentAggregate;
using HRManagement.Infrastructure.Context;
using HRManagement.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using static HRManagement.Shared.Enums;

namespace HRManagement.Infrastructure.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateDepartmentAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department.Id;
        }

        public async Task<Department> GetDepartmentByIdAsync(Guid id)
        {
            return await _context.Departments.FindAsync(id) ??
             throw new EntityNotFoundException(id, nameof(Department));
        }

        public async Task<(int totalCount, List<Department> departments)> GetDepartmentsAsync(int pageSize, int pageNumber, SortingDirection? sortingDirection, string? searchKey = null)
        {
            var query = _context.Departments.AsNoTracking();
            var skipCount = (pageNumber - 1) * pageSize;
            if (searchKey != null)
            {
                query = query.Where(d => d.NameAr.Contains(searchKey) || d.NameEn.Contains(searchKey));
            }
            if (sortingDirection == SortingDirection.DESC)
            {
                query = query.OrderByDescending(d => d.NameAr).Skip(skipCount).Take(pageSize);
            }
            else
            {
                query = query.OrderBy(d => d.NameEn).Skip(skipCount).Take(pageSize);

            }
            var totalCount = await query.CountAsync();

            return (totalCount, await query.ToListAsync());
        }

    }
}
