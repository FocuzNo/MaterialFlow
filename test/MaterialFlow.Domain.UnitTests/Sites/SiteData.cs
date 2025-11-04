using MaterialFlow.Domain.Sites;

namespace MaterialFlow.Domain.UnitTests.Sites;

internal static class SiteData
{
    public static Site CreateSite(
        Guid? id = null,
        string? plantCode = null,
        string? name = null) =>
        Site.Create(
            id ?? Guid.NewGuid(),
            plantCode ?? "PLANT-001",
            name ?? "Main Manufacturing Plant");
}