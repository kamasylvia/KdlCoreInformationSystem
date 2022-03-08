using MediatR;

namespace WorkshopSchedule.Application.Queries.EventQueries;

public record ConfirmServerQuery : IRequest<ConfirmServerResponse>
{
    public string? Challenge { get; set; }
    public string? Token { get; set; }
    public string? Type { get; set; }
}

public record ConfirmServerResponse
{
    public string? Challenge { get; set; }
}
