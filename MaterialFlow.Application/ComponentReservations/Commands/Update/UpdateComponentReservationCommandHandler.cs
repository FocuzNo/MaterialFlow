using MaterialFlow.Application.ComponentReservations.Commands.Update;
using MaterialFlow.Domain.ComponentReservations;

public sealed class UpdateComponentReservationCommandHandler(
    IComponentReservationRepository componentReservationRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateComponentReservationCommand, Result>
{
    public async Task<Result> Handle(
        UpdateComponentReservationCommand request,
        CancellationToken cancellationToken)
    {
        var componentReservation = await componentReservationRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (componentReservation is null)
        {
            return Result.Failure(ComponentReservationErrors.NotFound);
        }

        componentReservation.Update(
            request.RequirementDate,
            new Quantity(
                request.QuantityAmount,
                new UnitOfMeasure(request.QuantityUnitOfMeasure)),
            ReservationStatus.FromValue(request.Status));

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
