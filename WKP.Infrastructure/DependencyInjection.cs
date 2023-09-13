using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;
using WKP.Infrastructure.Persistence;

namespace WKP.Infrastructure
{
    public static class DependencyInjection
    {
       public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
       {
            services.AddDbContext<WKPContext>(options =>
                options.UseSqlServer(configuration["Data:Wkpconnect:ConnectionString"],
                options => options.EnableRetryOnFailure(
                    maxRetryCount: 6,
                    maxRetryDelay: System.TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null)
                ));

            services.AddScoped<IFeeRepository, FeeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
       }
    }
}