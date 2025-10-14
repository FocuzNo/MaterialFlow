using MaterialFlow.Domain.Materials;

namespace MaterialFlow.Application.Materials.Commands.Deactivate;

internal sealed class DeactivateMaterialCommandHandler(
    IMaterialRepository materialRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeactivateMaterialCommand, Result>
{
    public async Task<Result> Handle(
        DeactivateMaterialCommand request,
        CancellationToken cancellationToken)
    {
        var material = await materialRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (material is null)
        {
            return Result.Failure(MaterialErrors.NotFound);
        }

        material.Deactivate();

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}