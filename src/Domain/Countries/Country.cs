namespace Domain.Countries;

public class Country
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Capital { get; set; }
    public string PhoneCode { get; set; }
    public bool IsActive { get; set; }
}

