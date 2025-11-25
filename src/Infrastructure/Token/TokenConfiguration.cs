using Domain.Token;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Token;

public class TokenConfiguration : IEntityTypeConfiguration<Tokens>
{
    public void Configure(EntityTypeBuilder<Tokens> builder)
    {
        builder.HasKey(c => c.TokenId);
        builder.HasOne<User>().WithMany().HasForeignKey(t => t.UserId);
        builder.Property(c => c.AppId).IsRequired();
        builder.Property(c => c.Accesstoken).IsRequired().HasColumnType("text");
        builder.Property(c => c.Refreshtoken).IsRequired().HasColumnType("text");
        builder.Property(c => c.IssuedAt).IsRequired();
    }
}
