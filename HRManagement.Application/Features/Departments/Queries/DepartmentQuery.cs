using AutoMapper;
using HRManagement.Application.Baeses;
using HRManagement.Application.Contracts.Departments.Dtos.QueryDtos;
using HRManagement.Application.Contracts.Departments.Dtos.ResponseDtos;
using HRManagement.Application.Contracts.Departments.Interfaces;
using HRManagement.Domain.Aggregates.DepartmentAggregate;

namespace HRManagement.Application.Features.Departments.Queries
{
    public class DepartmentQuery : IDepartmentQuery
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentQuery(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<DepartmentResponseDto>> GetDepartmentsAsync(DepartmentQueryDto dto)
        {
            var departments = await _departmentRepository.GetDepartmentsAsync(dto.PageSize, dto.PageNumber, dto.SortingDirection, dto.SearchKey);
            var mappedList = _mapper.Map<List<Department>, List<DepartmentResponseDto>>(departments.departments);
            return new PaginatedResult<DepartmentResponseDto>(mappedList, departments.totalCount);

        }
    }
}
