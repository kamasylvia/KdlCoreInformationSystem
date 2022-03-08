using MediatR;

namespace WorkshopSchedule.Application.Queries.TestQueries;

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
