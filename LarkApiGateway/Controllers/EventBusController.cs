using LarkApiGateway.Application.Requests.Commands.EventBusCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LarkApiGateway.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventBusController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventBusController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> ResolveEventMessage(LarkEventMessage request)
    {
        return Ok(await _mediator.Send(request));
    }
}
