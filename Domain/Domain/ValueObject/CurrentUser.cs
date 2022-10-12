using Domain.Identity;

namespace Domain.ValueObject;

public class CurrentUser
{
    private AppUser _User { get; set; }
    
    private CurrentUser(AppUser user)
    {
        _User = user;
    }

    public void GetCurrentUser()
    {
        
    }
}