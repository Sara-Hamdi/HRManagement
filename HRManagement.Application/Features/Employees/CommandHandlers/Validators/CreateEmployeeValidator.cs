using FluentValidation;
using HRManagement.Application.Features.Employees.CommandHandlers.Commands;

namespace HRManagement.Application.Features.Employees.CommandHandlers.Validators
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeCommand>
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
