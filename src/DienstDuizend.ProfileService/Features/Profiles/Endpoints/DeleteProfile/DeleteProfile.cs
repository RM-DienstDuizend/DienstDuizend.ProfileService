using DienstDuizend.Events;
using DienstDuizend.ProfileService.Features.Profiles.Domain.ValueObjects;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DienstDuizend.ProfileService.Features.Profiles.Endpoints.DeleteProfile;

public class UserDeletedAccountEventConsumer(DeleteProfile.Handler handler) : IConsumer<UserDeletedAccountEvent>
{
    public async Task Consume(ConsumeContext<UserDeletedAccountEvent> context)
    {
        var command = new DeleteProfile.Command(
            context.Message.UserId
        );

        await handler.HandleAsync(command);
    }
}