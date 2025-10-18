namespace MaterialFlow.Application.ForecastPlanItems.Commands.Delete;

internal sealed class DeleteForecastPlanItemCommandValidator : AbstractValidator<DeleteForecastPlanItemCommand>
{
    public DeleteForecastPlanItemCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}