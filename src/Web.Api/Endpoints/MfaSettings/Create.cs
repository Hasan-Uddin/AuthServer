using Application.Abstractions.Messaging;
using Application.MfaSettings.Create;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;
using Domain.MfaSettings; 

namespace Web.Api.Endpoints.MfaSettings;

public class Create : IEndpoint
{
    public sealed class Request
    {
        public Guid UserId { get; set; }
        public string SecretKey { get; set; }
        public string BackupCodes { get; set; }
        public string Method { get; set; } 
        public bool Enabled { get; set; }
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/MfaSettings", async (
            Request request,
            ICommandHandler<CreateMfaSettingCommand, Guid> handler,
            CancellationToken cancellationToken) =>
        {
            MfaMethod method = Enum.TryParse<MfaMethod>(request.Method, true, out MfaMethod parsedMethod)
              ? parsedMethod
               : MfaMethod.TOTP;
            var command = new CreateMfaSettingCommand
            {
                UserId = request.UserId,
                SecretKey = request.SecretKey,
                BackupCodes = request.BackupCodes,
                Method = method, 
                Enabled = request.Enabled
            };

            Result<Guid> result = await handler.Handle(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.MfaSettings) 
        .RequireAuthorization();
    }
}
