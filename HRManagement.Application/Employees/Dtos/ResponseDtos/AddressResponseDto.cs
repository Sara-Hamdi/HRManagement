using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Employees.Dtos.ResponseDtos
{
    public class AddressResponseDto
    {
        public required string Region { get; set; }
        public required string City { get; set; }
        public string? Notes { get; set; }
    }
}
