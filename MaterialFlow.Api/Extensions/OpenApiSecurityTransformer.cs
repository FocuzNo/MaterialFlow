using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace MaterialFlow.Api.Extensions;

internal sealed class OpenApiAuthTransformer : IOpenApiDocumentTransformer
{
    private const string BearerScheme = "Bearer";
    private const string JwtBearerFormat = "JWT";
    private const string SecurityDescription = "JWT Bearer token authentication. Enter your token in the format: Bearer {your_token}";

    public Task TransformAsync(
        OpenApiDocument document,
        OpenApiDocumentTransformerContext context,
        CancellationToken cancellationToken)
    {
        AddSecurityScheme(document);
        ApplySecurityRequirementToAllOperations(document);

        return Task.CompletedTask;
    }

    private static void AddSecurityScheme(OpenApiDocument document)
    {
        document.Components ??= new OpenApiComponents();

        document.Components.SecuritySchemes[BearerScheme] = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = BearerScheme.ToLowerInvariant(),
            BearerFormat = JwtBearerFormat,
            Description = SecurityDescription
        };
    }

    private static void ApplySecurityRequirementToAllOperations(OpenApiDocument document)
    {
        if (document.Paths is null)
        {
            return;
        }

        foreach (OpenApiPathItem path in document.Paths.Values)
        {
            foreach (OpenApiOperation operation in path.Operations.Values)
            {
                operation.Security ??= [];

                operation.Security.Add(CreateBearerSecurityRequirement());
            }
        }
    }

    private static OpenApiSecurityRequirement CreateBearerSecurityRequirement()
    {
        var securityScheme = new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = BearerScheme
            }
        };

        return new OpenApiSecurityRequirement
        {
            [securityScheme] = []
        };
    }
}