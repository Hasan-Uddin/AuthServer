using Application.Abstractions.Messaging;
using Application.Countries.Get;
using SharedKernel;

namespace Application.Countries.Get;

public sealed record GetCountriesQuery() : IQuery<List<GetCountryResponse>>;
