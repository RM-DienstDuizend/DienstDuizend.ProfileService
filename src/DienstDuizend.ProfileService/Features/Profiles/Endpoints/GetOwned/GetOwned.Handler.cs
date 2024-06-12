using DienstDuizend.ProfileService.Common.Dto;
using DienstDuizend.ProfileService.Common.Extensions;
using DienstDuizend.ProfileService.Common.Interfaces;
using DienstDuizend.ProfileService.Features.Profiles.Domain;
using DienstDuizend.ProfileService.Infrastructure.Exceptions;
using DienstDuizend.ProfileService.Infrastructure.Persistence;
using Immediate.Handlers.Shared;
using Microsoft.EntityFrameworkCore;

namespace DienstDuizend.ProfileService.Features.Profiles.Endpoints.GetOwned;

[Handler]
public static partial class GetOwned
{
    public record Query;

    public record Response(Guid Id);

    private static async ValueTask<ProfileResponse> HandleAsync(
        Query _,
        ApplicationDbContext dbContext,
        ICurrentUserProvider currentUserProvider,
        CancellationToken token)
    {
        var profile = await dbContext.Profiles
            .FirstOrDefaultAsync(p => p.UserId == currentUserProvider.GetCurrentUserId(), token);

        if (profile is null) throw Error.Unexpected("Profile.NotFound", "Please contact our support team.");

        return profile.ToResponse();
    }
}