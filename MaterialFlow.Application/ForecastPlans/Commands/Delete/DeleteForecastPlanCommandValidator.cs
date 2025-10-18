namespace MaterialFlow.Application.ForecastPlans.Commands.Delete;

internal sealed class DeleteForecastPlanCommandValidator : AbstractValidator<DeleteForecastPlanCommand>
{
    public DeleteForecastPlanCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}