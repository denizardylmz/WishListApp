using Application.Common.Response;
using Application.Interfaces;
using MediatR;

namespace Application.Wish.Commands.CreateWishCommand;

public class CreateWishCommand : IRequest<IResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    
    public int WishListId { get; set; }
}

public class CreateWishCommandHandler : IRequestHandler<CreateWishCommand, IResponse>
{
    private readonly IAppDbContext _context;

    public CreateWishCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IResponse> Handle(CreateWishCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Wish()
        {
            Name = request.Name,
            Description = request.Description,
            Url = request.Url,

            WishListId = request.WishListId
        };
        
        var entityEntry = _context.Wishes.Add(entity);
        
        var result = await _context.SaveChangesAsync(cancellationToken);

        return result > 0 ? Response<int>.Success("Wish created successfully", result) :
            Response.ErrorResponse("Wish creation failed", Array.Empty<string>());
    }
}