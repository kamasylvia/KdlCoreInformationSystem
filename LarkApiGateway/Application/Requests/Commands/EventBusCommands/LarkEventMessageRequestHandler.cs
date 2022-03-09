using System.Text.Json;
using LarkApiGateway.Application.Responses.EventBusResponses;
using LarkApiGateway.Utils;
using Dapr.Client;
using MediatR;

namespace LarkApiGateway.Application.Requests.Commands.EventBusCommands;

public class LarkEventMessageRequestHandler
    : IRequestHandler<LarkEventMessage, LarkEventMessageResonseBase>
{
    private readonly DaprClient _daprClient;

    public LarkEventMessageRequestHandler(DaprClient daprClient)
    {
        _daprClient = daprClient ?? throw new ArgumentNullException(nameof(daprClient));
    }

    public async Task<LarkEventMessageResonseBase> Handle(
        LarkEventMessage request,
        CancellationToken cancellationToken
    )
    {
        var encryptKey = await _daprClient.GetSecretAsync(
            "local-secret-store",
            "LarkEventSubscriptionEncryptKey"
        );
        var cipher = new AESCipher(encryptKey["LarkEventSubscriptionEncryptKey"]);
        var eventMessage = cipher.DecryptString(request.Encrypt);

        System.Console.WriteLine(eventMessage);

        return await ResolveEventMessage(eventMessage);
    }

    public async Task<LarkEventMessageResonseBase> ResolveEventMessage(string eventMessage)
    {
        using var jsonDocument = JsonDocument.Parse(eventMessage);
        var root = jsonDocument.RootElement;
        var eventType = root.GetProperty("type").GetString();

        if (eventType == "url_verification")
        {
            return new UrlVerificationResponse
            {
                Challenge = root.GetProperty("challenge").GetString()
            };
        }

        return new UrlVerificationResponse();
    }
}
