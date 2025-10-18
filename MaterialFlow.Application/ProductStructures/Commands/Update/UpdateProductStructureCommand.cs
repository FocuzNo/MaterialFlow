namespace MaterialFlow.Application.ProductStructures.Commands.Update;

public sealed record UpdateProductStructureCommand(
    Guid Id,
    Guid MaterialId,
    Guid? SiteId,
    int Usage,
    string? AlternativeNumber,
    DateOnly ValidFromDate,
    DateOnly? ValidToDate,
    int OrderStatus) : IRequest<Result>;