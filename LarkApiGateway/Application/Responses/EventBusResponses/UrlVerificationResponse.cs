namespace LarkApiGateway.Application.Responses.EventBusResponses;

public record UrlVerificationResponse : LarkEventMessageResonseBase
{
    public string? Challenge { get; set; }
}
