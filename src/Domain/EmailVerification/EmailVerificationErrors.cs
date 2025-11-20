using SharedKernel;

namespace Domain.EmailVerification;

public static class EmailVerificationErrors
{
    public static Error AlreadyCompleted(Guid Id) => Error.Problem(
        "Email verification.AlreadyCompleted",
        $"The Email Verification with Id = '{Id}' is already completed.");

    public static Error NotFound(Guid Id) => Error.NotFound(
        "Email verification",
        $"The Email Verification with the Id = '{Id}' was not found");
}
