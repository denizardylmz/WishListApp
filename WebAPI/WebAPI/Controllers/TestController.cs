using System.Security.Claims;
using Application.Interfaces;
using Application.WishList.Commands.CreateWishList;
using Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IMediator _mediator;
        
        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost("CreateWishList")]
        public async Task<int> CreateWishList([FromBody] CreateWishListCommand request)
        {
            return await _mediator.Send(request);
        }
        
    }
}
