using SharedKernel;

namespace Domain.PasswordResets;

public static class PasswordResetsErrors
{
    public static Error AlreadyCompleted(Guid Id) => Error.Problem(
        "Password Reset.AlreadyCompleted",
        $"The Password reset with Id = '{Id}' is already completed.");

    public static Error NotFound(Guid Id) => Error.NotFound(
        "Password Reset.NotFound",
        $"The password reset with the Id = '{Id}' was not found");
}
