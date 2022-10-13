using Application.Common.Response;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Wish.Queries.GetAllWishesQuery;

public class GetAllWishesRequest : IRequest<IResponse>
{
    
}

public class GetAllWishesQueryHandler : IRequestHandler<GetAllWishesRequest, IResponse>
{
    private readonly IAppDbContext _context;


    public GetAllWishesQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IResponse> Handle(GetAllWishesRequest request, CancellationToken cancellationToken)
    {
        var wishes = await _context.Wishes.ToListAsync(cancellationToken);
        
        return Response<List<Domain.Entities.Wish>>.Success("Wishes retrieved successfully", wishes);
    }
}