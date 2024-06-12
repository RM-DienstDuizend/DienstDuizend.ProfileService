using DienstDuizend.ProfileService.Features.Profiles.Domain;
using DienstDuizend.ProfileService.Infrastructure.Exceptions;
using DienstDuizend.ProfileService.Infrastructure.Persistence;
using Immediate.Handlers.Shared;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace DienstDuizend.ProfileService.Features.Profiles.Endpoints.DeleteProfile;

[Handler]
public static partial class DeleteProfile
{
    public record Command(Guid UserId);

    public record Response;
    
    private static async ValueTask<Response> HandleAsync(
        Command request,
        ApplicationDbContext dbContext,
        IPublishEndpoint publishEndpoint,
        CancellationToken token)
    {
        
        Profile? profile = await dbContext.Profiles
            .FirstOrDefaultAsync(b => b.UserId == request.UserId, token);
        
        if (profile is null) throw Error.NotFound<Profile>();
        
        dbContext.Profiles.Remove(profile);
        await dbContext.SaveChangesAsync(token);
        
        return new Response() {};
    }
}

