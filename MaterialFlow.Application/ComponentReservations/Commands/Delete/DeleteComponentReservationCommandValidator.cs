namespace MaterialFlow.Application.ComponentReservations.Commands.Delete;

public sealed class DeleteComponentReservationCommandValidator : AbstractValidator<DeleteComponentReservationCommand>
{
    public DeleteComponentReservationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
    }
}