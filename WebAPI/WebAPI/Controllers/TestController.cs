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
        IIdentityService _identityService;
        private IMediator _mediator;
        private UserManager<AppUser> _userManager;
        private IHttpContextAccessor _accessor;
        private RoleManager<AppRole> _roleManager;


        public TestController(IIdentityService identityService, IMediator mediator, UserManager<AppUser> userManager, IHttpContextAccessor accessor, RoleManager<AppRole> roleManager)
        {
            _identityService = identityService;
            _mediator = mediator;
            _userManager = userManager;
            _accessor = accessor;
            _roleManager = roleManager;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(string name, string email, string password)
        {
            var res = await _identityService.CreateUserAsync(name, email, password);
            
            return Ok(res);
        }
        
        [HttpPost("LogIn")]
        public async Task<AppUser> LogIn(string userName, string password)
        {
            var res = await _identityService.LogInAsync(userName, password);
            return res;
        }

        [HttpGet("Make")]
        public async Task MakeThinksHappen()
        {
            await _identityService.CreateUserAsync("test", "test@hotmail.com", "Test123!");
            var role = new AppRole();
            role.Name = "Role1";
            await _roleManager.CreateAsync(role);
            var user = await _userManager.FindByNameAsync("test");
            await _userManager.AddToRoleAsync(user, "Role1");

        }


        [Authorize(Roles = "Role1")]
        [HttpPost("Test1")]
        public async Task<int> CreateWishList([FromBody] CreateWishListCommand request)
        {
            return await _mediator.Send(request);
        }
        
    }
}
