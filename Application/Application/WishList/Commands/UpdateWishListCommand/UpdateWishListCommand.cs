using Application.Common.Models;
using Application.Common.Response;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.WishList.Commands;

public class UpdateWishListCommand : IRequest<IResponse>
{ 
    public UpdateWishListDTO WishList { get; set; }
}

public class UpdateWishListCommandHandler : IRequestHandler<UpdateWishListCommand, IResponse>
{
    private readonly IAppDbContext _context;


    public UpdateWishListCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IResponse> Handle(UpdateWishListCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.WishLists.FirstOrDefaultAsync(e => e.Id == request.WishList.Id, cancellationToken: cancellationToken);
        
        if (entity != null)
        {
            entity.Name = request.WishList.Name;
            entity.Description = request.WishList.Description;
            _context.WishLists.Update(entity);
            var res = await _context.SaveChangesAsync(cancellationToken);
            return res > 0 ? Response<int>.Success("Wish list updated successfully", res) 
                : Response.ErrorResponse("Failed to update wish list", Array.Empty<string>());
        }
        
        return Response.NotFoundResponse("Wish list not found");
    }
}