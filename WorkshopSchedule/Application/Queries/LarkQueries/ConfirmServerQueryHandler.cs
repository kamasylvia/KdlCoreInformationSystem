using MediatR;

namespace WorkshopSchedule.Application.Queries.LarkQueries;

public class ConfirmServerQueryHandler : IRequestHandler<ConfirmServerQuery, ConfirmServerResponse>
{
    public async Task<ConfirmServerResponse> Handle(
        ConfirmServerQuery request,
        CancellationToken cancellationToken
    ) => new ConfirmServerResponse { Challenge = request.Challenge };
}
