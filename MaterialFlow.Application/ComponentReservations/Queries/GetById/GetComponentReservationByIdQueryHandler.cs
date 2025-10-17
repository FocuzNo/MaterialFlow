using MaterialFlow.Domain.ComponentReservations;

namespace MaterialFlow.Application.ComponentReservations.Queries.GetById;

internal sealed class GetComponentReservationByIdQueryHandler(IComponentReservationRepository componentReservationRepository)
    : IRequestHandler<GetComponentReservationByIdQuery, Result<ComponentReservationResponse>>
{
    public async Task<Result<ComponentReservationResponse>> Handle(
        GetComponentReservationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var componentReservation = await componentReservationRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (componentReservation is null)
        {
            return Result.Failure<ComponentReservationResponse>(ComponentReservationErrors.NotFound);
        }

        var response = new ComponentReservationResponse(
            componentReservation.Id,
            componentReservation.SourceOrderType,
            componentReservation.SourceOrderId,
            componentReservation.MaterialId,
            componentReservation.Material.MaterialNumber.Value,
            componentReservation.SiteId,
            componentReservation.Site.Name,
            componentReservation.RequirementDate,
            componentReservation.Quantity.Amount,
            componentReservation.Quantity.UnitOfMeasure.Value,
            componentReservation.Status.Name);

        return Result.Success(response);
    }
}