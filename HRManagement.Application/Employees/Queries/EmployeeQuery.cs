using AutoMapper;
using HRManagement.Application.Baeses;
using HRManagement.Application.Employees.Dtos.RequestDtos;
using HRManagement.Application.Employees.Dtos.ResponseDtos;
using HRManagement.Application.Employees.Interfaces;
using HRManagement.Domain.Aggregates.EmployeeAggregate;
using HRManagement.Domain.ViewModels;

namespace HRManagement.Application.Employees.Queries
{
    public class EmployeeQuery : IEmployeeQuery
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeQuery(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeResponseDto> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetEmployeeWithDetailsAsync(id);
            return _mapper.Map<EmployeeViewModel, EmployeeResponseDto>(employee);

        }

        public async Task<List<EmployeeResponseDto>> GetEmployeesAsync(Guid? departmentId = null)
        {
            var employees = await _employeeRepository.GetEmployeesAsync(departmentId);
            return _mapper.Map<List<EmployeeViewModel>, List<EmployeeResponseDto>>(employees);
        }

        public async Task<PaginatedResult<EmployeeResponseDto>> GetEmployeesPaginatedAsync(EmployeeQueryDto dto)
        {
            var result = await _employeeRepository.GetEmployeesPaginatedAsync(dto.PageSize, dto.PageNumber, dto.SortingDirection, dto.DepartmentId, dto.SearchKey);
            var employees = _mapper.Map<List<EmployeeViewModel>, List<EmployeeResponseDto>>(result.employees);
            return new PaginatedResult<EmployeeResponseDto>(employees, result.totalCount);

        }
    }
}
