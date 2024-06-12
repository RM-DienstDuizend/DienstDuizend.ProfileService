using DienstDuizend.ProfileService.Features.Profiles.Domain.ValueObjects;

namespace DienstDuizend.ProfileService.Features.Profiles.Domain;

public class Profile
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Email Email { get; set; }
    public string FirstName { get; set;  }
    public string LastName { get; set;  }
    public List<PostalAddress> SavedPostalAddresses { get; set; } = new();

}