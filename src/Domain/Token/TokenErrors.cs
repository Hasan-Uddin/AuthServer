using SharedKernel;

namespace Domain.Token;

public static class TokenErrors
{
    public static Error AlreadyCompleted(Guid Id) => Error.Problem(
        "Token.AlreadyCompleted",
        $"The token with Id = '{Id}' is already completed.");

    public static Error NotFound(Guid Id) => Error.NotFound(
        "Tokens.NotFound",
        $"The token with the Id = '{Id}' was not found");
}
