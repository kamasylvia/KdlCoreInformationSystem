using LarkApiGateway.Application.Responses.EventBusResponses;
using MediatR;

namespace LarkApiGateway.Application.Requests.Commands.EventBusCommands;

public record LarkEventMessage : IRequest<LarkEventMessageResonseBase>
{
    public string? Encrypt { get; set; }
}
