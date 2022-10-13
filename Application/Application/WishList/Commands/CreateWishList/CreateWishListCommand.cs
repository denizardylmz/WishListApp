using Application.Common.Response;
using Application.Interfaces;
using MediatR;

namespace Application.WishList.Commands.CreateWishList;

public class CreateWishListCommand : IRequest<IResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    
}