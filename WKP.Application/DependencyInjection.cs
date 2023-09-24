using BuberDinner.Api.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WKP.Application.Application.Common;
using WKP.Application.Common.Helpers;
using WKP.Application.Common.Interfaces;
using WKP.Application.Features.Common;
using WKP.Infrastructure.GeneralServices.Interfaces;

namespace WKP.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMappings();
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services.AddTransient<AppHelper>();
            services.AddTransient<Helper>();
            services.AddTransient<AppStatusHelper>();
            
            return services;
        }
    }
}