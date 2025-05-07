using FluentValidation;
using HRManagement.Application.Users.Dtos;
using HRManagement.Domain.Shared;

namespace HRManagement.Application.Users.Validators
{
    public class RegisterUserRequestDtoValidator : AbstractValidator<RegisterUserRequestDto>
    {
        public RegisterUserRequestDtoValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty().MaximumLength(Constants.StringLengths.SmallLength);
            RuleFor(c => c.LastName).NotEmpty().MaximumLength(Constants.StringLengths.SmallLength);
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.PhoneNumber).NotEmpty();
            RuleFor(c => c.Password).NotEmpty().MinimumLength(10);
            RuleFor(c => c.ConfirmedPassword).NotEmpty().Matches(c => c.Password);
            RuleFor(c => c.EmployeeDetails).NotNull()
                .ChildRules(emp =>
                {
                    emp.RuleFor(e => e.DepartmentId).NotEmpty();
                    emp.RuleFor(e => e.NationalId).NotEmpty();
                    emp.RuleFor(e => e.NetSalary).NotEmpty();
                    emp.RuleFor(e => e.GrossSalary).NotEmpty();
                    emp.RuleFor(e => e.PositionId).NotEmpty();
                });



        }
    }
}
