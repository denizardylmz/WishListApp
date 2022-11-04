using System.Security.Claims;
using Application.Interfaces;
using Application.Wish.Queries.GetWishByPagination;
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
        private readonly IMediator _mediator;
        private readonly IIdentityService _service;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;


        public TestController(IMediator mediator, IIdentityService service, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _mediator = mediator;
            _service = service;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpPost("create")]
        public async Task<string> CreateUser(string name, string email, string password)
        {
            var user = new AppUser
            {
                UserName = name,
                Email = email
            };
            var result = await _service.CreateUserAsync(name, email, password);
            var role = new AppRole();
            role.Name = "admin";
            await _roleManager.CreateAsync(role);
            var a = await _service.AddRoleToUserAsync(result.userId, "admin");
            return result.userId;
        }

        [HttpPost("SignIn")]
        public async Task<AppUser> SignIn(string name, string password)
        {
            var a = await _service.LogInAsync(name, password);
            return a;
        }

        [HttpGet("signout")]
        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        } 
        
        
        [HttpPost("Get")]
        [Authorize(Roles = "admin")]
        public Task<IResponse> GetWishWithPagination(GetWishByPaginationRequest request, CancellationToken cancellationToken)
        {
            // Progress<string> progress = new Progress<string>();
            // progress.ProgressChanged += (sender, e) => Console.WriteLine(e);
            // request.Progress = progress;
            
            return _mediator.Send(request, cancellationToken);
        }


    }
}
