using MaterialFlow.Domain.ComponentReservations;

namespace MaterialFlow.Application.ComponentReservations.Commands.Delete;

internal sealed class DeleteComponentReservationCommandHandler(
    IComponentReservationRepository componentReservationRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteComponentReservationCommand, Result>
{
    public async Task<Result> Handle(
        DeleteComponentReservationCommand request,
        CancellationToken cancellationToken)
    {
        var componentReservation = await componentReservationRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (componentReservation is null)
        {
            return Result.Failure(ComponentReservationErrors.NotFound);
        }

        componentReservationRepository.Delete(componentReservation);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}