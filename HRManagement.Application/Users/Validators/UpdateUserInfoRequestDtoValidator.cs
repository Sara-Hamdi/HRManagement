using FluentValidation;
using HRManagement.Application.Users.Dtos;

namespace HRManagement.Application.Users.Validators
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
