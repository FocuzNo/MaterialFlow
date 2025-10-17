using MaterialFlow.Domain.ComponentReservations;

namespace MaterialFlow.Application.ComponentReservations.Queries.GetAll;

internal sealed class GetAllComponentReservationsQueryHandler(IComponentReservationRepository componentReservationRepository)
    : IRequestHandler<GetAllComponentReservationsQuery, Result<IReadOnlyCollection<ComponentReservationResponse>>>
{
    public async Task<Result<IReadOnlyCollection<ComponentReservationResponse>>> Handle(
        GetAllComponentReservationsQuery request,
        CancellationToken cancellationToken)
    {
        var componentReservations = await componentReservationRepository.GetAllAsync(cancellationToken);

        IReadOnlyCollection<ComponentReservationResponse> response = [.. componentReservations
            .Select(x => new ComponentReservationResponse(
                x.Id,
                x.SourceOrderType,
                x.SourceOrderId,
                x.MaterialId,
                x.Material.MaterialNumber.Value,
                x.SiteId,
                x.Site.Name,
                x.RequirementDate,
                x.Quantity.Amount,
                x.Quantity.UnitOfMeasure.Value,
                x.Status.Name)
            )];

        return Result.Success(response);
    }
}