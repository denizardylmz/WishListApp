using Application.Common.Response;
using Application.Interfaces;
using Application.WishList.Commands.CreateWishList;
using Domain.Entities;
using Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.WishList.Commands.Handlers;

public class CreateWishListHandler : IRequestHandler<CreateWishListCommand, IResponse>
{
    private IAppDbContext _context;

    public CreateWishListHandler(IAppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IResponse> Handle(CreateWishListCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.WishList
        {
            Name = request.Name,
            Description = request.Description
        };
        await _context.WishLists.AddAsync(entity, cancellationToken);
        var res = await _context.SaveChangesAsync(cancellationToken);
        if (res > 0)
        {
            return Response<int>.Success("WishList Created", entity.Id);
        }

        return Response.ErrorResponse("WishList Not Created", null);
    }
}