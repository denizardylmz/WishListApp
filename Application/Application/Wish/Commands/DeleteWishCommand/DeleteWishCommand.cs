using Application.Common.Response;
using Application.Interfaces;
using Application.WishList.Commands.DeleteWishList;
using MediatR;

namespace Application.Wish.Commands.DeleteWishCommand;

public class DeleteWishCommand : IRequest<IResponse>
{
    public int Id { get; set; }
}

public class DeleteWishCommandHandler : IRequestHandler<DeleteWishCommand, IResponse>
{
    private readonly IAppDbContext _context;


    public DeleteWishCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IResponse> Handle(DeleteWishCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Wishes.FindAsync(request.Id);
        
        if (entity == null)
        {
            return Response.NotFoundResponse("Wish not Found");
        }
        
        _context.Wishes.Remove(entity);
        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result > 0)
        {
            return Response.SuccessResponse("Wish Deleted Successfully");
        }
        return Response.ErrorResponse("Wish Not Deleted", Array.Empty<string>());
    }
}