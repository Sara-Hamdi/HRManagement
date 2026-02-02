using FluentValidation;
using HRManagement.Application.Contracts.Users.Dtos;

namespace HRManagement.Application.Features.Users.Validators
{
    public class ChangeUserPasswordRequestDtoValidator : AbstractValidator<ChangeUserPasswordRequestDto>
    {
        public ChangeUserPasswordRequestDtoValidator()
        {
            RuleFor(c => c.CurrentPassword).NotEmpty().MinimumLength(10);
            RuleFor(c => c.NewPassword).NotEmpty().MinimumLength(10);
            RuleFor(c => c.ConfirmNewPassword).NotEmpty().Equal(c => c.NewPassword);
        }
    }
}
