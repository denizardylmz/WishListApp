using MediatR;

namespace Application.WishList.Commands.CreateWishList;

public class CreateWishListCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    
}