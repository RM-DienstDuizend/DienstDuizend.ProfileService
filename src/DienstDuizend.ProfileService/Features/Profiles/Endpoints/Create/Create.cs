using DienstDuizend.Events;
using DienstDuizend.ProfileService.Features.Profiles.Domain.ValueObjects;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DienstDuizend.ProfileService.Features.Profiles.Endpoints.Create;

public class UserRegisteredConsumer(Create.Handler handler) : IConsumer<UserRegisteredEvent>
{
    public async Task Consume(ConsumeContext<UserRegisteredEvent> context)
    {
        var command = new Create.Command(
            context.Message.UserId,
            Email.From(context.Message.Email),
            context.Message.FirstName, 
            context.Message.LastName
        );

        await handler.HandleAsync(command);
    }
}