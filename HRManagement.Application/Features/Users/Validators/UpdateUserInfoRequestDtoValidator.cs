using FluentValidation;
using HRManagement.Application.Contracts.Users.Dtos;

namespace HRManagement.Application.Features.Users.Validators
{
    public class UpdateUserInfoRequestDtoValidator : AbstractValidator<UpdateUserInfoRequestDto>
    {
        public UpdateUserInfoRequestDtoValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .When(u => !string.IsNullOrEmpty(u.Email));
        }
    }
}
