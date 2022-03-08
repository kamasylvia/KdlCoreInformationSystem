using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkshopSchedule.Application.Queries.EventQueries;

namespace WorkshopSchedule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost("check")]
    public async Task<ActionResult<ConfirmServerResponse>> CheckUrl(ConfirmServerQuery request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpPost]
    public async Task<ActionResult<ConfirmServerResponse>> Event(ConfirmServerQuery request)
    {
        return Ok(await _mediator.Send(request));
    }
}
