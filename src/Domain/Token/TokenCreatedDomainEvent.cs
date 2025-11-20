using SharedKernel;

namespace Domain.Token;

public sealed record TokenCreatedDomainEvent(Guid Id) : IDomainEvent;
