using DienstDuizend.ProfileService.Common.Dto;
using DienstDuizend.ProfileService.Features.Profiles.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DienstDuizend.ProfileService.Features.Profiles.Endpoints.GetOwned;

[ApiController, Route("/")]
[Authorize]
public class GetOwnedEndpoint(GetOwned.Handler handler) : ControllerBase
{
    [HttpGet]
    public async Task<ProfileResponse> HandleAsync(
        CancellationToken cancellationToken = new()
    ) => await handler.HandleAsync(new GetOwned.Query(), cancellationToken);
}