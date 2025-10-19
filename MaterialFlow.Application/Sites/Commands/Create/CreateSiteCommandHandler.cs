using MaterialFlow.Application.Sites.Commands.Create;
using MaterialFlow.Domain.Sites;

internal sealed class CreateSiteCommandHandler(
    ISiteRepository siteRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateSiteCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        CreateSiteCommand request,
        CancellationToken cancellationToken)
    {
        var isUnique = await siteRepository.IsUniqueAsync(
            request.PlantCode,
            cancellationToken);

        if (!isUnique)
        {
            return Result.Failure<Guid>(SiteErrors.AlreadyExists);
        }

        var site = Site.Create(
            Guid.NewGuid(),
            request.PlantCode,
            request.Name);

        await siteRepository.AddAsync(
            site,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(site.Id);
    }
}