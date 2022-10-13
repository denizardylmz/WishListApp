using FluentValidation;

namespace Application.Wish.Commands.CreateWishCommand;

public class CreateWishValidation : AbstractValidator<CreateWishCommand>
{
    public CreateWishValidation()
    {
        RuleFor(p => p.Name).MinimumLength(3).WithMessage("Name must be at least 3 characters long");
        RuleFor(p => p.Description).MinimumLength(3).WithMessage("Description must be at least 3 characters long");
        RuleFor(p => p.Url).NotEmpty().NotNull().WithMessage("Url must be provided");
        
        RuleFor(p=> p.WishListId).NotEmpty().NotNull().WithMessage("WishListId must be provided");
        
    }
}