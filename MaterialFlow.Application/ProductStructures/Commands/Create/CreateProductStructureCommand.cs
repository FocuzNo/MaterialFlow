namespace MaterialFlow.Application.ProductStructures.Commands.Create;

public sealed record CreateProductStructureCommand(
    Guid MaterialId,
    Guid? SiteId,
    int Usage,
    string? AlternativeNumber,
    DateOnly ValidFromDate,
    DateOnly? ValidToDate,
    int OrderStatus) : IRequest<Guid>;