using MaterialFlow.Domain.ComponentReservations;

namespace MaterialFlow.Application.ComponentReservations.Commands.Create;

internal sealed class CreateComponentReservationCommandHandler(
    IComponentReservationRepository componentReservationRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateComponentReservationCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateComponentReservationCommand request,
        CancellationToken cancellationToken)
    {
        var componentReservation = ComponentReservation.Create(
            Guid.NewGuid(),
            request.SourceOrderType,
            request.SourceOrderId,
            request.MaterialId,
            request.SiteId,
            request.RequirementDate,
            new Quantity(
                request.QuantityAmount,
                new UnitOfMeasure(request.QuantityUnitOfMeasure)),
            ReservationStatus.FromValue(request.Status));

        await componentReservationRepository.AddAsync(
            componentReservation,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return componentReservation.Id;
    }
}