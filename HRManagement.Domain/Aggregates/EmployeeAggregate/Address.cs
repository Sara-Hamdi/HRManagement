using HRManagement.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace HRManagement.Domain.Aggregates.EmployeesAggregates
{
    public class Address
    {
        public Guid Id { get; private set; }
        [StringLength(Constants.StringLengths.SmallLength)]
        public string Region { get; private set; }
        [StringLength(Constants.StringLengths.SmallLength)]
        public string City { get; private set; }
        [StringLength(Constants.StringLengths.SmallLength)]
        public string? Notes { get; private set; }

        public Address(string city, string region, string? notes = null)
        {
            Id = Guid.NewGuid();
            Region = region;
            City = city;
            Notes = notes;
        }
        public Address Update(string? city, string? region, string? notes = null)
        {
            Region = region ?? Region;
            City = city ?? City;
            Notes = notes;
            return this;
        }
    }
}
