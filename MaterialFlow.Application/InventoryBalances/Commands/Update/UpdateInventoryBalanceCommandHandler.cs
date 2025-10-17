using MaterialFlow.Domain.InventoryBalances;

namespace MaterialFlow.Application.InventoryBalances.Commands.Update;

public sealed class UpdateInventoryBalanceCommandHandler(
    IInventoryBalanceRepository repository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateInventoryBalanceCommand, Result>
{
    public async Task<Result> Handle(UpdateInventoryBalanceCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            return Result.Failure(InventoryBalanceErrors.NotFound);
        }

        entity.Update(
            new Quantity(request.OnHandAmount, new UnitOfMeasure(request.OnHandUnit)),
            new Quantity(request.ReservedAmount, new UnitOfMeasure(request.ReservedUnit)),
            request.Batch);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
