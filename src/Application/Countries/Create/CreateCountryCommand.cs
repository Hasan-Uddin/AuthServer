using Application.Abstractions.Messaging;
using SharedKernel;

namespace Application.Countries.Create;

public class CreateCountryCommand : ICommand<Guid>
{
    public string Name { get; set; }
    public string Capital { get; set; }
    public string PhoneCode { get; set; }
    public bool IsActive { get; set; }
};

