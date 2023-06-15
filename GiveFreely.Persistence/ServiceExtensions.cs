using GiveFreely.Application.Repositories;
using GiveFreely.Persistence.Context;
using GiveFreely.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GiveFreely.Persistence;

public static class ServiceExtensions{
    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgreSQL");
        services.AddDbContext<DataContext>(opt => opt.UseNpgsql(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAffiliateRepository, AffiliateRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }
}