using DienstDuizend.ProfileService.Features.Profiles.Domain;
using DienstDuizend.ProfileService.Features.Profiles.Domain.ValueObjects;
using DienstDuizend.ProfileService.Infrastructure.Persistence;
using Immediate.Handlers.Shared;
using MassTransit;

namespace DienstDuizend.ProfileService.Features.Profiles.Endpoints.Create;

[Handler]
public static partial class Create
{
    public record Command(
        Guid UserId,
        Email Email,
        string FirstName,
        string LastName
    );

    public record Response;
    
    private static async ValueTask<Response> HandleAsync(
        Command request,
        ApplicationDbContext dbContext,
        CancellationToken token)
    {
        var profile = new Profile()
        {
            UserId = request.UserId,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        await dbContext.Profiles.AddAsync(profile, token);
        await dbContext.SaveChangesAsync(token);
        
        return new Response();
    }
}

