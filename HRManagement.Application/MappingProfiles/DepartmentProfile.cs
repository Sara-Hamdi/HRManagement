using AutoMapper;
using HRManagement.Application.Features.Departments.QueryHandlers.Responses;
using HRManagement.Domain.Aggregates.DepartmentAggregate;

namespace HRManagement.Application.MappingProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentResponseDto>();

        }
    }
}
