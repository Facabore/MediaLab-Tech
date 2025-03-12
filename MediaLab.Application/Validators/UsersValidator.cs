using FluentValidation;
using MediaLab.Application.Dtos;
using MediaLab.Domain.Entities.User;

namespace MediaLab.Application.Validators;

public class UsersValidator : AbstractValidator<UserDTO>
{
    public UsersValidator()
    {
        RuleFor(user => user.FullName)
            .NotEmpty().WithMessage("Name is required ")
            .NotNull();

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");
    }
}