using AutoMapper;
using HRManagement.Application.Employees.Dtos.RequestDtos;
using HRManagement.Application.Employees.Dtos.ResponseDtos;
using HRManagement.Domain.Aggregates.EmployeesAggregates;
using HRManagement.Domain.ViewModels;

namespace HRManagement.Application.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<AddressViewModel, AddressResponseDto>();
            CreateMap<EmployeeViewModel, EmployeeResponseDto>();

            CreateMap<Address, AddressResponseDto>();
            CreateMap<Employee, EmployeeResponseDto>();

            CreateMap<AddressRequestDto, Address>(MemberList.Source);
            CreateMap<CreateEmployeeRequestDto, Employee>();

            CreateMap<UpdateEmployeeRequestDto, Employee>();

        }
    }
}
