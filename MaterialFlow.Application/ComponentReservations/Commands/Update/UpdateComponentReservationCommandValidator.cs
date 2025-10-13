namespace MaterialFlow.Application.ComponentReservations.Commands.Update;

public sealed class UpdateComponentReservationCommandValidator : AbstractValidator<UpdateComponentReservationCommand>
{
    public UpdateComponentReservationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(x => x.RequirementDate)
            .NotEmpty()
            .WithMessage("Requirement date is required.");

        RuleFor(x => x.QuantityAmount)
            .GreaterThan(0)
            .WithMessage("Quantity amount must be greater than zero.");

        RuleFor(x => x.UnitOfMeasure)
            .NotEmpty()
            .WithMessage("Unit of measure is required.");

        RuleFor(x => x.Status)
            .GreaterThan(0)
            .WithMessage("Invalid status.");
    }
}