using Application.Common.Response;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.WishList.Queries.GetAllWishLists;

public class GetAllWishListRequest : IRequest<Response<Domain.Entities.WishList>>
{
}

public class GetAllWishListHandler : IRequestHandler<GetAllWishListRequest, Response>
{
    private readonly IAppDbContext _context;

    public GetAllWishListHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(GetAllWishListRequest request, CancellationToken cancellationToken)
    {
        var wishLists = await _context.WishLists.ToListAsync();

        return Response<List<Domain.Entities.WishList>>.Success(wishLists, "Success");
    }
}
