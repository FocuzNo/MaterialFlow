using MaterialFlow.Domain.ForecastPlans;
using MaterialFlow.Domain.Materials.Enums;

namespace MaterialFlow.Application.ForecastPlans.Commands.Create;

internal sealed class CreateForecastPlanCommandHandler(
    IForecastPlanRepository forecastPlanRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateForecastPlanCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateForecastPlanCommand request,
        CancellationToken cancellationToken)
    {
        var forecastPlan = ForecastPlan.Create(
            Guid.NewGuid(),
            request.MaterialId,
            request.SiteId,
            request.PlanningAreaId,
            request.Version,
            request.PlanningStrategy,
            new UnitOfMeasure(request.UnitOfMeasure),
            PeriodGranularity.FromValue(request.PeriodGranularity),
            new DateRange(request.StartDate, request.EndDate));

        await forecastPlanRepository.AddAsync(
            forecastPlan,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return forecastPlan.Id;
    }
}