using Application.Common.Response;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.WishList.Queries.GetAllWishLists;

public class GetAllWishListRequest : IRequest<IResponse>
{
}

public class GetAllWishListHandler : IRequestHandler<GetAllWishListRequest, IResponse>
{
    private readonly IAppDbContext _context;

    public GetAllWishListHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IResponse> Handle(GetAllWishListRequest request, CancellationToken cancellationToken)
    {
        var wishLists = await _context.WishLists.ToListAsync(cancellationToken);

        return Response<List<Domain.Entities.WishList>>.Success("Success", wishLists);
    }
}
