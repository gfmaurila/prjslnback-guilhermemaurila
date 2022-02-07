using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prjslnback.API.Token;
using Prjslnback.Infra.Interfaces;
using Prjslnback.Infra.Repositories;
using Prjslnback.Services.Interfaces;
using Prjslnback.Services.Services;

namespace Prjslnback.API.Utilities.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection DependencyInjectionConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IEPasswordService, EPasswordService>();
            services.AddTransient<IEPasswordRepository, EPasswordRepository>();
            services.AddTransient<ITokenGenerator, TokenGenerator>();
            return services;
        }
    }
}
