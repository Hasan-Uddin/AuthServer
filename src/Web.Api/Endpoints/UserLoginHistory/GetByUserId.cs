using Application.Abstractions.Messaging;
using Application.UserLoginHistories.GetByUserId;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.UserLoginHistory;

internal sealed class GetByUserId : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("api/user-login-history/get", async (
           [FromQuery] Guid userId,
            IQueryHandler<GetUserLoginHistoryByUserIdQuery, List<UserLoginHistoryResponse>> handler,
            CancellationToken cancellationToken) =>
        {
            var query = new GetUserLoginHistoryByUserIdQuery(userId);

            Result<List<UserLoginHistoryResponse>> result = await handler.Handle(query, cancellationToken);
            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.UserLoginHistory)
        .RequireAuthorization();
    }
}
