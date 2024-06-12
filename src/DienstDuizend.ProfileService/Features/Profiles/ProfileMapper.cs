using DienstDuizend.ProfileService.Features.Profiles.Domain;
using Riok.Mapperly.Abstractions;

namespace DienstDuizend.ProfileService.Features.Profiles;

[Mapper]
public static  partial class ProfileMapper
{
    [MapProperty(nameof(Profile.UserId), nameof(ProfileResponse.Id))]
    public static partial ProfileResponse ToResponse(this Profile profile);
    
}