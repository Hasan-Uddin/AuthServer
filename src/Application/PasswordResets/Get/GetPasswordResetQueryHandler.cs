using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Users;
using Domain.PasswordResets;
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

        List<PasswordResetResponse> passwordResets = await context.PasswordReset
            .Where(passwordResets => passwordResets.Id == query.UserId)
            .Select(passwordReset => new PasswordResetResponse
            {
                User_Id = passwordReset.Id,
                Token = passwordReset.Token,
                Expires_at = passwordReset.Expires_at,
                Used = passwordReset.Used
            }).ToListAsync(cancellationToken);

        return passwordResets;
    }
}
