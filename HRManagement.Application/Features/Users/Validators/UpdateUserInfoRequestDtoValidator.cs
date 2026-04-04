using FluentValidation;
using HRManagement.Application.Features.Users.CommandHandlers.Commands;

namespace HRManagement.Application.Features.Users.Validators
{
    public class UpdateUserInfoRequestDtoValidator : AbstractValidator<UpdateUserInfoCommand>
    {
        public UpdateUserInfoRequestDtoValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .When(u => !string.IsNullOrEmpty(u.Email));
        }
    }
}
