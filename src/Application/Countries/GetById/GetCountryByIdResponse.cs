namespace Application.Countries.GetById;

public sealed class GetCountryByIdResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Capital { get; set; }
    public string PhoneCode { get; set; }
    public bool IsActive { get; set; }
}
