using Application.Abstractions.Messaging;

namespace Application.Countries.Update;

public sealed class UpdateCountryCommand() : ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Capital { get; set; }
    public string PhoneCode { get; set; }
    public bool IsActive { get; set; }
}
