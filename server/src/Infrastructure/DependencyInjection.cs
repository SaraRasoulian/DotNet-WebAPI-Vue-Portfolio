using Application.Interfaces;
using Infrastructure.DbContexts;
using Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Setting DBContexts
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<PortfolioDbContext>(options => options.UseNpgsql(connectionString, o => o.UseNodaTime()));
        services.AddHealthChecks().AddNpgSql(connectionString, "PortfolioDB");

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}