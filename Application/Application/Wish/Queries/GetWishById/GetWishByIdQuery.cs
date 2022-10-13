using Application.Common.Response;
using Application.Interfaces;
using MediatR;

namespace Application.Wish.Queries.GetWishById;

public class GetWishByIdRequest : IRequest<IResponse>
{
    public int Id { get; set; }
}


public class GetWishByIdQueryHandler : IRequestHandler<GetWishByIdRequest, IResponse>
{
    private readonly IAppDbContext _context;

    public GetWishByIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IResponse> Handle(GetWishByIdRequest request, CancellationToken cancellationToken)
    {
        var wish = await _context.Wishes.FindAsync(request.Id);
        
        if (wish == null)
        {
            return Response.NotFoundResponse("Wish not found");
        }
        
        return Response<Domain.Entities.Wish>.Success("Wish found", wish);
        
    }
}