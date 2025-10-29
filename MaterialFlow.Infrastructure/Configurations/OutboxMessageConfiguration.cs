using MaterialFlow.Infrastructure.Outbox;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class OutboxMessageConfiguration : BaseEntityConfiguration<OutboxMessage>
{
    public override void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Type)
            .HasMaxLength(255);

        builder.Property(x => x.Content)
            .IsRequired()
            .HasColumnType("jsonb");

        builder.HasIndex(x => new
        {
            x.OccurredOnUtc,
            x.ProcessedOnUtc
        })
        .HasDatabaseName("idx_outbox_unprocessed")
        .HasFilter("\"processed_on_utc\" IS NULL");
    }
}