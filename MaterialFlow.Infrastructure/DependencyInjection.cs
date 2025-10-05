using MaterialFlow.Domain.Abstractions;
using MaterialFlow.Domain.Materials;
using MaterialFlow.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MaterialFlow.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString = configuration
            .GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention());

        services.AddScoped<IMaterialRepository, MaterialRepository>();

        services.AddScoped<IUnitOfWork>(x => x.GetRequiredService<ApplicationDbContext>());

        return services;
    }
}
