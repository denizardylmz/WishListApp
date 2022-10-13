using Application.Common.Response;
using Application.Interfaces;
using MediatR;

namespace Application.WishList.Queries.GetWishListById;

public class GetWishListByIdRequest : IRequest<IResponse>
{
    public int Id { get; set; }
}


public class GetWishListByIdHandler : IRequestHandler<GetWishListByIdRequest, IResponse>
{
    private readonly IAppDbContext _context;


    public GetWishListByIdHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IResponse> Handle(GetWishListByIdRequest request, CancellationToken cancellationToken)
    {
        var wishList = _context.WishLists.FirstOrDefault(w => w.Id == request.Id);

        if (wishList == null)
        {
            return Response.NotFoundResponse("WishList not found");
        }
        
        return Response<Domain.Entities.WishList>.Success("WishList found successfully", wishList);
    }
} 