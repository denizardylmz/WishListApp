using Application.Interfaces;
using Application.WishList.Commands.CreateWishList;
using Domain.Entities;
using Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.WishList.Commands.Handlers;

public class CreateWishListHandler : IRequestHandler<CreateWishListCommand, int>
{
    private IAppDbContext _context;
    private ICurrentUser _currentUser;
    private UserManager<AppUser> _userManager;

    public CreateWishListHandler(IAppDbContext context, ICurrentUser currentUser, UserManager<AppUser> userManager)
    {
        _context = context;
        _currentUser = currentUser;
        _userManager = userManager;
    }
    
    public async Task<int> Handle(CreateWishListCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(_currentUser.UserName); 
        
        var entity = new Domain.Entities.WishList
        {
            Name = request.Name,
            Description = request.Description,
            User = new HashSet<AppUser>()
            {
                new(){Id = user.Id}
            }
        };
        
        await _context.WishLists.AddAsync(entity, cancellationToken);
        return await _context.SaveChangesAsync(cancellationToken);
    }
}