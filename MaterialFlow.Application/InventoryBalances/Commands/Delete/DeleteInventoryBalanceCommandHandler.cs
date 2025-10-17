using MaterialFlow.Domain.InventoryBalances;

namespace MaterialFlow.Application.InventoryBalances.Commands.Delete;

public sealed class DeleteInventoryBalanceCommandHandler(
    IInventoryBalanceRepository repository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteInventoryBalanceCommand, Result>
{
    public async Task<Result> Handle(DeleteInventoryBalanceCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id, cancellationToken);

        if (entity is null)
        {
            return Result.Failure(InventoryBalanceErrors.NotFound);
        }

        repository.Delete(entity);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
