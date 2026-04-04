using AutoMapper;
using HRManagement.Application.Features.Employees.CommandHandlers.Commands;
using HRManagement.Application.Features.Employees.QueriesHandlers.Responses;
using HRManagement.Domain.Aggregates.EmployeeAggregate;
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
            CreateMap<CreateEmployeeCommand, Employee>();

            CreateMap<UpdateEmployeeCommand, Employee>();

        }
    }
}
