using Application.Abstractions.Messaging;
using Domain.Businesses;

namespace Application.Businesses.Update;

public sealed class UpdateBusinessCommand() : ICommand
{
    public Guid Id { get; init; }

    public string BusinessName { get; init; }

    public string IndustryType { get; init; }

    public string LogoUrl { get; init; }

    public BusinessStatus Status { get; init; }
}
