using MaterialFlow.Domain.Users;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(x => x.Email, e =>
        {
            e.Property(p => p.Value)
             .HasMaxLength(255);
        });

        builder.OwnsOne(x => x.FirstName, fn =>
        {
            fn.Property(p => p.Value)
              .HasMaxLength(100);
        });

        builder.OwnsOne(x => x.LastName, ln =>
        {
            ln.Property(p => p.Value)
              .HasMaxLength(100);
        });

        builder.Property(x => x.PasswordHash)
               .HasMaxLength(500);

        builder.Property(x => x.IdentityId)
               .HasMaxLength(255);

        builder.HasIndex(x => x.IdentityId);
    }
}
