using System;
using System.Collections.Generic;
using System.Text;
using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Users.GetAll;

internal sealed class GetAllUsersQueryHandler(
    IApplicationDbContext context,
    IUserContext userContext) : IQueryHandler<GetAllUsersQuery, List<GetAllUsersQueryResponse>>
{
    public async Task<Result<List<GetAllUsersQueryResponse>>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        if (query.Id != userContext.UserId)
        {
            return Result.Failure<List<GetAllUsersQueryResponse>>(UserErrors.Unauthorized());
        }

        List<GetAllUsersQueryResponse> users = await context.Users
            .AsNoTracking()
            .Select(user => new GetAllUsersQueryResponse
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Phone = user.Phone,
                IsEmailVerified = user.IsEmailVerified,
                IsMFAEnabled = user.IsMFAEnabled,
                Status = user.Status,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            })
            .ToListAsync(cancellationToken: cancellationToken);

        return Result.Success(users);
    }
}
