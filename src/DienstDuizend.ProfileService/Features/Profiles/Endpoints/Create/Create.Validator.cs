using FluentValidation;

namespace DienstDuizend.ProfileService.Features.Profiles.Endpoints.Create;

public class CreateValidator : AbstractValidator<Create.Command>
{
    public CreateValidator()
    {
    }       
}
