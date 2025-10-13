using MaterialFlow.Domain.ForecastPlans;
using MaterialFlow.Domain.Materials.Enums;

namespace MaterialFlow.Application.ForecastPlans.Commands.Update;

internal sealed class UpdateForecastPlanCommandHandler(
    IForecastPlanRepository forecastPlanRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateForecastPlanCommand, Result>
{
    public async Task<Result> Handle(
        UpdateForecastPlanCommand request,
        CancellationToken cancellationToken)
    {
        var forecastPlan = await forecastPlanRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (forecastPlan is null)
        {
            return Result.Failure(ForecastPlanErrors.NotFound);
        }

        forecastPlan.Update(
            request.Version,
            request.PlanningStrategy,
            new UnitOfMeasure(request.UnitOfMeasure),
            PeriodGranularity.FromValue(request.PeriodGranularity),
            new DateRange(
                request.StartDate,
                request.EndDate));

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
