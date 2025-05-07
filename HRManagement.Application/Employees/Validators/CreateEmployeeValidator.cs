using FluentValidation;
using HRManagement.Application.Employees.Dtos.RequestDtos;

namespace HRManagement.Application.Employees.Validators
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeRequestDto>
    {

        public CreateEmployeeValidator()
        {
            RuleFor(c => c.Address)
           .NotNull()
           .WithMessage("Address is required")
           .ChildRules(address =>
           {
               address.RuleFor(a => a.City)
               .NotEmpty()
               .WithMessage("City is required");
               address.RuleFor(a => a.Region)
               .NotEmpty()
               .WithMessage("Region is required");

           });


        }

    }
}
