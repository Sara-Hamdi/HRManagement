using AutoMapper;
using HRManagement.Application.Employees.Dtos.RequestDtos;
using HRManagement.Application.Users.Dtos;
using HRManagement.Domain.Aggregates.EmployeeAggregate;
using HRManagement.Domain.Aggregates.UserAggregate;
using HRManagement.Domain.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using static HRManagement.Domain.Shared.Constants;

namespace HRManagement.Application.Users.CommandHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserRequestDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly EmployeeManager _employeeManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(UserManager<User> userManager, EmployeeManager employeeManager, IMapper mapper, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _employeeManager = employeeManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }
        public async Task Handle(RegisterUserRequestDto request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var employee = await _employeeManager.CheckIfEmployeeExist(request.EmployeeDetails.NationalId!);
            if (user != null)
            {
                throw new BusinessException(ErrorCodes.EmailAlreadyExists);
            }
            if (employee != null)
            {
                throw new BusinessException(ErrorCodes.EmployeeAlreadyExists);
            }
            var newUser = new User(request.FirstName, request.LastName, request.Email);
            await _userManager.CreateAsync(newUser, request.Password);

            await ConfirmRolesExistenceAsync();

            await _userManager.AddToRoleAsync(newUser, Roles.Employee);
            if (request.Role != null)
            {
                await _userManager.AddToRoleAsync(newUser, request.Role);
            }

            request.EmployeeDetails.UserId = newUser.Id;
            var newEmployee = _mapper.Map<CreateEmployeeRequestDto, Employee>(request.EmployeeDetails);
            await _employeeManager.CreateEmployeeAsync(newEmployee);


        }
        private async Task ConfirmRolesExistenceAsync()
        {
            if (!await _roleManager.RoleExistsAsync(Roles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(Roles.Admin));

            if (!await _roleManager.RoleExistsAsync(Roles.TeamLeader))
                await _roleManager.CreateAsync(new IdentityRole(Roles.TeamLeader));

            if (!await _roleManager.RoleExistsAsync(Roles.Employee))
                await _roleManager.CreateAsync(new IdentityRole(Roles.Employee));

        }

    }
}
