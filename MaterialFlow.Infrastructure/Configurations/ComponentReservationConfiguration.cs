using MaterialFlow.Domain.ComponentReservations;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Infrastructure.Configurations;

internal sealed class ComponentReservationConfiguration : BaseEntityConfiguration<ComponentReservation>
{
    public override void Configure(EntityTypeBuilder<ComponentReservation> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(x => x.Quantity, q =>
        {
            q.Property(p => p.Amount)
                .HasPrecision(18, 3);

            q.OwnsOne(p => p.UnitOfMeasure, uom =>
            {
                uom.Property(u => u.Value)
                   .HasMaxLength(20);
            });
        });

        builder.Property(x => x.Status)
            .HasConversion(
                x => x.Name,
                x => ReservationStatus.FromName(x))
            .HasMaxLength(50);
    }
}
