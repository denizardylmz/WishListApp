using FluentValidation;

namespace Application.Wish.Commands.DeleteWishCommand;

public class DeleteWishCommandValidator : AbstractValidator<DeleteWishCommand>
{
    public DeleteWishCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().NotNull().WithMessage("Id is required");
    }
}