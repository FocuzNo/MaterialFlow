using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Application.Sites.Commands.Update;

internal sealed class UpdateSiteCommandHandler(
    ISiteRepository siteRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateSiteCommand, Result>
{
    public async Task<Result> Handle(
        UpdateSiteCommand request,
        CancellationToken cancellationToken)
    {
        var site = await siteRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (site is null)
        {
            return Result.Failure(SiteErrors.NotFound);
        }

        site.Update(
            request.PlantCode,
            request.Name);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}