using FluentValidation;

namespace Application.WishList.Commands.CreateWishList;

public class CreateWishListValidator : AbstractValidator<CreateWishListCommand>
{
    public CreateWishListValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Description).MinimumLength(5);
    }
}