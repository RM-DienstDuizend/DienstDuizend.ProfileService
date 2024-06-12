using FluentValidation;

namespace DienstDuizend.ProfileService.Features.Profiles.Endpoints.Update;


public class UpdateValidator : AbstractValidator<Update.Command>
{
    public UpdateValidator()
    {
    }       
}
