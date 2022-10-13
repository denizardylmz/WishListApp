using Application.Common.Response;
using Application.Interfaces;
using Application.WishList.Commands;
using Application.WishList.Commands.CreateWishList;
using Application.WishList.Commands.DeleteWishList;
using Application.WishList.Queries.GetAllWishLists;
using Application.WishList.Queries.GetWishListById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WishListController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        //Get All WishLists
        [HttpPost("GetAll")]
        public async Task<IResponse> GetAll(GetAllWishListRequest request)
        {
            return await _mediator.Send(request);
        }

        //Get WishList By Id
        [HttpPost("GetById")]
        public async Task<IResponse> GetById([FromBody]GetWishListByIdRequest request)
        {
            return await _mediator.Send(request);
        }
        
        //Create WishList
        [HttpPost("Create")]
        public Task<IResponse> Create(CreateWishListCommand command)
        {
            return _mediator.Send(command);
        }
        
        //Delete WishList
        [HttpPost("Update")]
        public async Task<IResponse> Update(UpdateWishListCommand command)
        {
            return await _mediator.Send(command);
        }
        
        //Delete WishList
        [HttpPost("Delete")]
        public Task<IResponse> Delete(DeleteWishListCommand command)
        {
            return _mediator.Send(command);
        }


    }
}
