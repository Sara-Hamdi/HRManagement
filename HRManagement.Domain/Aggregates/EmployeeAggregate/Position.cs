using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Domain.Aggregates.EmployeesAggregates
{
    public class Position
    {
        public Guid Id { get; private set; }
        [StringLength(100)]
        public string NameAr { get; private set; } = string.Empty;
        [StringLength(100)]
        public string NameEn { get; private set; } = string.Empty;

    }
}
