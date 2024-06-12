using DienstDuizend.ProfileService.Features.Profiles.Domain;
using DienstDuizend.ProfileService.Infrastructure.Exceptions;
using DienstDuizend.ProfileService.Infrastructure.Persistence;
using Immediate.Handlers.Shared;
using Microsoft.EntityFrameworkCore;


namespace DienstDuizend.ProfileService.Features.Profiles.Endpoints.Update;

[Handler]
public static partial class Update
{
    public record Command(Guid Id );

    public record Response;

    private static async ValueTask<Response> HandleAsync(
        Command request,
        ApplicationDbContext dbContext,
        CancellationToken token)
    {
        Profile? profile = await dbContext.Profiles.FirstOrDefaultAsync(b => b.Id == request.Id, token);
        if (profile is null) throw Error.NotFound<Profile>();
        
        await dbContext.SaveChangesAsync(token);

        return new Response();
    }
}

