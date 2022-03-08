using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkshopSchedule.Application.Queries.LarkQueries;

namespace WorkshopSchedule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LarkController : ControllerBase
{
    private readonly IMediator _mediator;
    public LarkController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<ActionResult<ConfirmServerResponse>> ConfirmServer(ConfirmServerQuery request)
    {
        return Ok(await _mediator.Send(request));
    }
}
