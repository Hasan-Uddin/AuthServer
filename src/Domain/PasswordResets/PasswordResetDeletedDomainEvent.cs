using SharedKernel;

namespace Domain.PasswordResets;

public sealed record PasswordResetDeletedDomainEvent(Guid Id) : IDomainEvent;
