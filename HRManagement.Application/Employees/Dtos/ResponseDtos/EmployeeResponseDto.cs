using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Employees.Dtos.ResponseDtos
{
    public class EmployeeResponseDto
    {
        public required string FullName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Department { get; set; }
        public double NetSalary { get; set; }
        public double GrossSalary { get; set; }
        public required string Position { get; set; }
        public AddressResponseDto? Address { get; set; }
    }
}
