using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Application.Sites.Commands.Delete;

internal sealed class DeleteSiteCommandHandler(
    ISiteRepository siteRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteSiteCommand, Result>
{
    public async Task<Result> Handle(
        DeleteSiteCommand request,
        CancellationToken cancellationToken)
    {
        var site = await siteRepository.GetByIdAsync(
            request.Id,
            cancellationToken);

        if (site is null)
        {
            return Result.Failure(SiteErrors.NotFound);
        }

        siteRepository.Delete(site);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}