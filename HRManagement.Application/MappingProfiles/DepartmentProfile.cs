using AutoMapper;
using HRManagement.Application.Contracts.Departments.Dtos.ResponseDtos;
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
