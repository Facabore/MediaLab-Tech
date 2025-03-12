using FluentValidation;
using MediaLab.Application.Dtos;

namespace MediaLab.Application.Validators;

public sealed class MessageValidator : AbstractValidator<MessageDTO>
{
    public MessageValidator()
    {
        RuleFor(message => message.Content)
            .NotEmpty().WithMessage("The content can't be empty")
            .NotNull().WithMessage("The content can't be null");

    }
}