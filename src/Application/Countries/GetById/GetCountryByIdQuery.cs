using Application.Abstractions.Messaging;
using Application.Businesses.GetById;

namespace Application.Countries.GetById;

public sealed record GetCountryByIdQuery(Guid Id) : IQuery<GetCountryByIdResponse>;
