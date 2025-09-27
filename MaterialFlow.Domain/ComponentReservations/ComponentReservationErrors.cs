namespace MaterialFlow.Domain.ComponentReservations;

public static class ComponentReservationErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(ComponentReservation)}.{NotFound}",
        "The component reservation with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(ComponentReservation)}.{InvalidUpdate}",
        "The component reservation update is invalid");
}