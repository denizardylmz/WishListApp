using Application.Common.Extensions;
using Application.Common.Models;
using Application.Common.Response;
using Application.Interfaces;
using MediatR;

namespace Application.Wish.Queries.GetWishByPagination;

public class GetWishByPaginationRequest : IRequest<IResponse>
{
    public int ListId { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }


    //For progress testing
    //public IProgress<string>? Progress { get; set; }
}
public class GetWishByPaginationHandler : IRequestHandler<GetWishByPaginationRequest, IResponse>
{
    private readonly IAppDbContext _context;

    public GetWishByPaginationHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IResponse> Handle(GetWishByPaginationRequest request, CancellationToken cancellationToken)
    {
        var queryable = _context.Wishes.AsQueryable(); 
        var data = await queryable.Where(p => p.WishListId == request.ListId)
            .PaginationListAsync(request.PageNumber, request.PageSize, cancellationToken);

        if(!data.Data.Any())
            return Response.NotFoundResponse("Wish not found");
        
        //For progress test
        //request.Progress.Report("Your wishes are ready");
        
        return Response<PaginationList<Domain.Entities.Wish>>.Success("Wishes found", data);
    }
}