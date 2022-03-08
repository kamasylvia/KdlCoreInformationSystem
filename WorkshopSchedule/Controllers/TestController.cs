using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorkshopSchedule.Application.Queries.TestQueries;

namespace WorkshopSchedule.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IMediator _mediator;

    public TestController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost]
    public async Task<ActionResult<ConfirmServerResponse>> ConfirmServer(ConfirmServerQuery request)
    {
        return Ok(await _mediator.Send(request));
    }
}
