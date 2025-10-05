using Microsoft.AspNetCore.Routing;

namespace MaterialFlow.Presentation.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}
