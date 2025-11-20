using Application.Abstractions.Data;
using Domain.AuditLogs;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Web.Api.Endpoints.AuditLogs;

public static class Update
{
    public static void MapUpdateAuditLogEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPut("/AuditLogs/{id}", async (
            Guid id,
            UpdateAuditLogRequest request,
            IApplicationDbContext context,
            CancellationToken cancellationToken) =>
        {
            
            AuditLog? auditLog = await context.AuditLogs
                .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (auditLog is null)
            {
                return Results.NotFound(Result.Failure(AuditLogErrors.NotFound(id)));
            }

            auditLog.Action = request.Action;
            auditLog.Description = request.Description;
            auditLog.UpdatedAt = DateTime.UtcNow;

            await context.SaveChangesAsync(cancellationToken);

            return Results.Ok(Result.Success());
        })
        .WithName("UpdateAuditLog")
        .WithTags(Tags.AuditLogs) 
        .RequireAuthorization()
        .WithSummary("Update an Audit Log entry")
        .WithDescription("Updates the Action and Description of an Audit Log");
    }
}

public sealed record UpdateAuditLogRequest(
    string Action,
    string Description
);
