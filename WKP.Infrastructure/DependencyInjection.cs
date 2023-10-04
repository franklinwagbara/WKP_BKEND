using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WKP.Application.Common.Interfaces;
using WKP.Domain.Repositories;
using WKP.Infrastructure.Context;
using WKP.Infrastructure.GeneralServices;
using WKP.Infrastructure.GeneralServices.Implementations;
using WKP.Infrastructure.GeneralServices.Interfaces;
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
            services.AddScoped<IEmailAuditMessage, EmailAuditMessage>();
            services.AddScoped<EmailHelper>();
            services.AddTransient<IStaffNotifier, StaffNotifier>();
            services.AddTransient<ICompanyNotifier, CompanyNotifier>();
            services.AddTransient<IAppLogger, EmailAuditMessage>();
            services.AddScoped<IRNGenerator, RNGenerator>();

            //HangFire setup
            services.AddHangfire(x => x.UseSqlServerStorage(configuration["Data:Wkpconnect:ConnectionString"]));
            services.AddHangfireServer();

            return services;
       }
    }
}