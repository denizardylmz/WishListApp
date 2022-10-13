using Application.Common.Response;
using Application.Interfaces;
using Application.WishList.Commands;
using MediatR;

namespace Application.Wish.Commands.UpdateWishCommand;

public class UpdateWishCommand : IRequest<IResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
}

public class UpdateWishCommandHandler : IRequestHandler<UpdateWishCommand, IResponse>
{
    private readonly IAppDbContext _context;

    public UpdateWishCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IResponse> Handle(UpdateWishCommand request, CancellationToken cancellationToken)
    {
        var entityToUpdate = await _context.Wishes.FindAsync(request.Id);
        
        if (entityToUpdate == null)
        {
            return Response.NotFoundResponse("Wish not found");
        }

        entityToUpdate.Name = request.Name;
        entityToUpdate.Description = request.Description;
        entityToUpdate.Url = request.Url;

        _context.Wishes.Update(entityToUpdate);
        var result = await _context.SaveChangesAsync(cancellationToken);

        if (result > 0)
        {
            return Response.SuccessResponse("Wish updated successfully");
        }
        return Response.ErrorResponse("Wish not updated", Array.Empty<string>());
    }
}