using FluentValidation;

namespace Application.WishList.Commands.CreateWishList;

public class CreateWishListValidator : AbstractValidator<CreateWishListCommand>
{
    public CreateWishListValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).WithMessage("Minimum length of name is 3 characters");
        RuleFor(x => x.Description).MinimumLength(5).WithMessage("Minimum length of description is 5 characters");
    }
}