using AutoMapper;
using HRManagement.Application.Baeses;
using HRManagement.Application.Employees.Dtos.ResponseDtos;
using HRManagement.Application.Employees.Interfaces;
using HRManagement.Domain.Aggregates.EmployeesAggregates;
using HRManagement.Domain.ViewModels;

namespace HRManagement.Application.Employees.Queries
{
    public class EmployeeQuery : ResponseHandler, IEmployeeQuery
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeQuery(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Response<EmployeeResponseDto>> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
            var result = _mapper.Map<Employee, EmployeeResponseDto>(employee);
            if (result == null) return NotFound<EmployeeResponseDto>($"cannot find employee with id {id}");
            return Success(result);
        }

        public async Task<Response<List<EmployeeResponseDto>>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            var result = _mapper.Map<List<EmployeeViewModel>, List<EmployeeResponseDto>>(employees);

            return Success(result);

        }
    }
}
