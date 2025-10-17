using MaterialFlow.Domain.Abstractions;

namespace MaterialFlow.Infrastructure.Configurations;

public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);

        if (typeof(TEntity).GetProperty("CreatedAt") is not null)
        {
            builder.Property<DateTime>("CreatedAt")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();
        }

        if (typeof(TEntity).GetProperty("UpdatedAt") is not null)
        {
            builder.Property<DateTime>("UpdatedAt")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
