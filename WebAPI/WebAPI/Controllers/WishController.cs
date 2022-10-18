using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Wish.Commands.CreateWishCommand;
using Application.Wish.Commands.DeleteWishCommand;
using Application.Wish.Commands.UpdateWishCommand;
using Application.Wish.Queries.GetAllWishesQuery;
using Application.Wish.Queries.GetWishById;
using Application.Wish.Queries.GetWishByPagination;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WishController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Create Wish
        [HttpPost("CreateWish")]
        public Task<IResponse> Create(CreateWishCommand command)
        {
            return _mediator.Send(command);
        }
        
        //Update Wish
        [HttpPost("UpdateWish")]
        public Task<IResponse> Update(UpdateWishCommand command)
        {
            return _mediator.Send(command);
        }
        
        //Delete Wish
        [HttpPost("DeleteWish")]
        public Task<IResponse> Delete(DeleteWishCommand command)
        {
            return _mediator.Send(command);
        }

        //Get All Wishes
        [HttpPost("GetAllWishes")]
        public Task<IResponse> GetAll(GetAllWishesRequest request)
        {
            return _mediator.Send(request);
        }
        
        //Get Wish By Id
        [HttpPost("GetWishById")]
        public Task<IResponse> GetById(GetWishByIdRequest request)
        {
            return _mediator.Send(request);
        }

        //Get Wish By Pagination
        [HttpPost("GetWishByPagination")]
        public Task<IResponse> GetWishWithPagination(GetWishByPaginationRequest request, CancellationToken cancellationToken)
        {
            // Progress<string> progress = new Progress<string>();
            // progress.ProgressChanged += (sender, e) => Console.WriteLine(e);
            // request.Progress = progress;
            
            return _mediator.Send(request, cancellationToken);
        }
    }
}
