using BuberDinner.Api.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WKP.Application.Common.Helpers;

namespace WKP.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMappings();
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services.AddTransient<AppHelper>();
            
            return services;
        }
    }
}