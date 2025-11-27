namespace Application.PasswordResets.Get;

public sealed class PasswordResetResponse
{
    public Guid PrId { get; set; }
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool Used { get; set; }
}
