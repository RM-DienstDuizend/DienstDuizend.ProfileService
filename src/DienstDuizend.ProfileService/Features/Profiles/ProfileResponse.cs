using DienstDuizend.ProfileService.Features.Profiles.Domain;
using DienstDuizend.ProfileService.Features.Profiles.Domain.ValueObjects;

namespace DienstDuizend.ProfileService.Features.Profiles;

public record ProfileResponse(
    Guid Id, 
    Email Email, 
    string FirstName, 
    string LastName, 
    List<PostalAddress> SavedPostalAddresses
);