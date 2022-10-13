using Application.Common.Response;
using Application.Interfaces;
using MediatR;

namespace Application.WishList.Commands.DeleteWishList;

public class DeleteWishListCommand : IRequest<IResponse>
{
    public int WishListId { get; set; }
}

public class DeleteWishListHandler : IRequestHandler<DeleteWishListCommand, IResponse>
{
    private readonly IAppDbContext _context;

    public DeleteWishListHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IResponse> Handle(DeleteWishListCommand request, CancellationToken cancellationToken)
    {
        var wishList = _context.WishLists.FirstOrDefault(w => w.Id == request.WishListId);
        
        if (wishList == null)
        {
            return Response.NotFoundResponse("WishList not found");
        }
        _context.WishLists.Remove(wishList);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Response.SuccessResponse("WishList deleted successfully");
    }
}