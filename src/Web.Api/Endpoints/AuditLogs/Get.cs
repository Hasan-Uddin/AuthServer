using Microsoft.AspNetCore.Routing;
using Application.Abstractions.Messaging;
using Application.AuditLogs.Get;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.AuditLogs;

public static class GetAuditLogsEndpoint
{
    public static void MapGetAuditLogsEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/AuditLogs", async (
            IQueryHandler<GetAuditLogQuery, List<AuditLogResponse>> handler,
            CancellationToken cancellationToken) =>
        {
            // Explicit type
            Result<List<AuditLogResponse>> result = await handler.Handle(new GetAuditLogQuery(), cancellationToken);
            return result.Match(Results.Ok, CustomResults.Problem);

        })
        .WithTags(Tags.AuditLogs)
        .RequireAuthorization();
    }
}
