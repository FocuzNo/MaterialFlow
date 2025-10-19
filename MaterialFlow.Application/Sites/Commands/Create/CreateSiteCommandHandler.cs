using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Application.Sites.Commands.Create;

internal sealed class CreateSiteCommandHandler(
    ISiteRepository siteRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateSiteCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateSiteCommand request,
        CancellationToken cancellationToken)
    {
        var site = Site.Create(
            Guid.NewGuid(),
            request.PlantCode,
            request.Name);

        await siteRepository.AddAsync(
            site,
            cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return site.Id;
    }
}