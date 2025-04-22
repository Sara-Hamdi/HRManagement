using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Employees.Dtos.RequestDtos
{
    public class AddressRequestDto
    {
        public required string City { get; set; }
        public required string Region { get; set; }
        public string Notes { get; set; }
    }
}
