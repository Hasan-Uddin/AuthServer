using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.PasswordResets.Get;

internal sealed class GetPasswordResetQueryHandler(IApplicationDbContext context, IUserContext userContext)
    : IQueryHandler<GetPasswordResetQuery, List<PasswordResetResponse>>
{
    public async Task<Result<List<PasswordResetResponse>>> Handle(GetPasswordResetQuery query, CancellationToken cancellationToken)
    {
        if (query.UserId != userContext.UserId)
        {
            return Result.Failure<List<PasswordResetResponse>>(UserErrors.Unauthorized());
        }

        List<PasswordResetResponse> passwordResetResponse = await context.PasswordReset
            .Where(passwordResetResponse => passwordResetResponse.UserId == query.UserId)
            .Select(passwordResetResponse => new PasswordResetResponse
            {
                PrId = passwordResetResponse.PrId,
                UserId = passwordResetResponse.UserId,
                Token = passwordResetResponse.Token,
                ExpiresAt = passwordResetResponse.ExpiresAt,
                Used = passwordResetResponse.Used

            }).ToListAsync(cancellationToken);

        return passwordResetResponse;
    }
}
