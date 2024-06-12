using DienstDuizend.ProfileService.Features.Profiles.Domain;
using DienstDuizend.ProfileService.Features.Profiles.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DienstDuizend.ProfileService.Infrastructure.Persistence.EntityConfiguration;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.Property(e => e.Email)
            .HasConversion(new Email.EfCoreValueConverter());
    }
}