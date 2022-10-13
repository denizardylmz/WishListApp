using FluentValidation;

namespace Application.WishList.Commands;

public class UpdateWishListValidator : AbstractValidator<UpdateWishListCommand>
{
    public UpdateWishListValidator()
    {
        RuleFor(p => p.WishList.Name).MinimumLength(3).WithMessage("Name must be at least 3 characters long");
        
        RuleFor(p => p.WishList.Description).MinimumLength(3).WithMessage("Description must be at least 3 characters long");
    }
}