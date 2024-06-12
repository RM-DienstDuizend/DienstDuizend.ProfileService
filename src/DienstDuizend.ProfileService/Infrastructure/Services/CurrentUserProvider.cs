using System.Security.Claims;
using DienstDuizend.ProfileService.Common.Interfaces;
using DienstDuizend.ProfileService.Infrastructure.Exceptions;
using DienstDuizend.ProfileService.Infrastructure.Persistence;

namespace DienstDuizend.ProfileService.Infrastructure.Services;

public class CurrentUserProvider(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext) : ICurrentUserProvider
{
    public Guid GetCurrentUserId()
    {
        
        var user = httpContextAccessor.HttpContext?.User;
             
        var sub = user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        
        if (sub is null)
            throw Error.InternalError("User.UnknownUser", "The current user is unknown, try logging in again.");

        
        return Guid.Parse(sub);
    }
    
    // public string GetCurrentUserRole()
    // {
    //     var user = httpContextAccessor.HttpContext?.User;
    //         
    //     return user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
    // }
    
}