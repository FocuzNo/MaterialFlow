namespace MaterialFlow.Domain.Sites;

public static class SiteErrors
{
    public static readonly Error NotFound = new(
        $"{nameof(Site)}.{NotFound}",
        "The site with the specified identifier was not found");

    public static readonly Error InvalidUpdate = new(
        $"{nameof(Site)}.{InvalidUpdate}",
        "The site update is invalid");

    public static readonly Error AlreadyExists = new(
        $"{nameof(Site)}.{nameof(AlreadyExists)}",
        "A site with this plant code already exists");
}