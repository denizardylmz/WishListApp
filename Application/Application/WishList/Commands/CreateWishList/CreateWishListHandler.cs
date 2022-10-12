using Application.Interfaces;
using Application.WishList.Commands.CreateWishList;
using Domain.Entities;
using Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.WishList.Commands.Handlers;

public class CreateWishListHandler : IRequestHandler<CreateWishListCommand, int>
{
    private IAppDbContext _context;

    public CreateWishListHandler(IAppDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> Handle(CreateWishListCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.WishList
        {
            Name = request.Name,
            Description = request.Description
        };
        await _context.WishLists.AddAsync(entity, cancellationToken);
        return await _context.SaveChangesAsync(cancellationToken);
    }
}