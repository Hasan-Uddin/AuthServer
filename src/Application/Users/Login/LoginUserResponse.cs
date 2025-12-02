
using Domain.Users;

namespace Application.Users.Login;

public sealed record LoginUserResponse(
    string Token,
    string RefreshToken,
    LogInUserinfo User
);

public sealed record LogInUserinfo(
    Guid Id
);
