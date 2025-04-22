using HRManagement.Application.Baeses;
using HRManagement.Application.Employees.Dtos.ResponseDtos;
using HRManagement.Domain.Aggregates.EmployeesAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Employees.Interfaces
{
    public interface IEmployeeQuery
    {
        Task<Response<List<EmployeeResponseDto>>> GetEmployeesAsync();
        Task<Response<EmployeeResponseDto>> GetEmployeeByIdAsync(Guid id);
    }
}
