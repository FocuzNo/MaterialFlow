using MaterialFlow.Domain.ForecastPlans;

namespace MaterialFlow.Application.ForecastPlans.Commands.Delete;

internal sealed class DeleteForecastPlanCommandHandler(
    IForecastPlanRepository forecastPlanRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteForecastPlanCommand, Result>
{
    public async Task<Result> Handle(
        DeleteForecastPlanCommand request,
        CancellationToken cancellationToken)
    {
        var forecastPlan = await forecastPlanRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (forecastPlan is null)
        {
            return Result.Failure(ForecastPlanErrors.NotFound);
        }

        forecastPlanRepository.Delete(forecastPlan);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}