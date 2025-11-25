#pragma warning disable CA1054
using Application.Abstractions.Messaging;
using Domain.Businesses;

namespace Application.Businesses.Update;

public sealed record UpdateBusinessCommand(
    Guid Id,
    string BusinessName,
    string IndustryType,
    string LogoUrl,
    BusinessStatus Status) : ICommand;
