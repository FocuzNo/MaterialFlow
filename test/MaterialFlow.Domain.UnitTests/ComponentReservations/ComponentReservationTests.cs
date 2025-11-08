using MaterialFlow.Domain.ComponentReservations;
using MaterialFlow.Domain.Shared.ValueObjects;

namespace MaterialFlow.Domain.UnitTests.ComponentReservations;

public sealed class ComponentReservationTests : BaseTest
{
    [Fact]
    public void Create_ShouldInitializeReservation_WithCorrectProperties()
    {
        var id = Guid.NewGuid();
        var sourceOrderType = "ManufacturingOrder";
        var sourceOrderId = Guid.NewGuid();
        var materialId = Guid.NewGuid();
        var siteId = Guid.NewGuid();
        var requirementDate = new DateOnly(2025, 12, 15);
        var quantity = new Quantity(250, new UnitOfMeasure("Kilogram"));

        var reservation = ComponentReservation.Create(
            id,
            sourceOrderType,
            sourceOrderId,
            materialId,
            siteId,
            requirementDate,
            quantity);

        reservation.Id.Should().Be(id);
        reservation.SourceOrderType.Should().Be(sourceOrderType);
        reservation.SourceOrderId.Should().Be(sourceOrderId);
        reservation.MaterialId.Should().Be(materialId);
        reservation.SiteId.Should().Be(siteId);
        reservation.RequirementDate.Should().Be(requirementDate);
        reservation.Quantity.Should().Be(quantity);
        reservation.Status.Should().Be(ReservationStatus.Reserved);
    }

    [Fact]
    public void Create_WithoutStatus_ShouldDefaultToReserved()
    {
        var reservation = ComponentReservationData.CreateReservation();

        reservation.Status.Should().Be(ReservationStatus.Reserved);
    }

    [Fact]
    public void Create_WithStatus_ShouldUseProvidedStatus()
    {
        var reservation = ComponentReservationData.CreateReservation(
            status: ReservationStatus.Consumed);

        reservation.Status.Should().Be(ReservationStatus.Consumed);
    }

    [Fact]
    public void Update_ShouldModifyProperties()
    {
        var reservation = ComponentReservationData.CreateReservation();
        var newRequirementDate = new DateOnly(2026, 3, 20);
        var newQuantity = ComponentReservationData.CreateQuantity(750, "Liter");
        var newStatus = ReservationStatus.Consumed;

        reservation.Update(newRequirementDate, newQuantity, newStatus);

        reservation.RequirementDate.Should().Be(newRequirementDate);
        reservation.Quantity.Should().Be(newQuantity);
        reservation.Status.Should().Be(newStatus);
    }

    [Fact]
    public void Update_ShouldNotModify_OtherProperties()
    {
        var reservation = ComponentReservationData.CreateReservation();
        var originalSourceOrderType = reservation.SourceOrderType;
        var originalSourceOrderId = reservation.SourceOrderId;

        reservation.Update(
            new DateOnly(2026, 7, 8),
            ComponentReservationData.CreateQuantity(500),
            ReservationStatus.Cancelled);

        reservation.SourceOrderType.Should().Be(originalSourceOrderType);
        reservation.SourceOrderId.Should().Be(originalSourceOrderId);
    }
}